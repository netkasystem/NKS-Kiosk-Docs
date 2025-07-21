using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NThaiSmartWeb.EFModels;

public class CardReaderHub : Hub
{
    private readonly KioskContext _dbContext;
	private readonly IMemoryCache _memoryCache;
	public CardReaderHub(IMemoryCache memoryCache, KioskContext dbContext)
    {
		_memoryCache = memoryCache;
        _dbContext = dbContext;
	}

    // เก็บสถานะของแต่ละ kiosk โดยใช้ kioskId เป็น key
    private static readonly Dictionary<string, KioskStatusDto> _kioskConnections = new();

    // เก็บ mapping ระหว่าง connectionId → kioskId
    private static readonly Dictionary<string, string> _connectionToKioskMap = new();

    private static readonly object _lock = new(); // ใช้ lock ป้องกัน race condition

	private int HeartBeatInterval() =>
	    _memoryCache.GetOrCreate("health_check_interval_min", entry =>
	    {
		    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);

		    var value = _dbContext.Variables
			    .FirstOrDefault(v => v.Name == "health_check_interval_min")
			    ?.Value;

		    if (int.TryParse(value, out var min))
			    return min;

		    return 5;
	    });

	// ให้สิทธิภายนอก (เช่น Worker) เข้าถึงข้อมูล kiosk status ปัจจุบัน
	public static Dictionary<string, KioskStatusDto> GetKioskStatusMap() => _kioskConnections;

    // รับคำขอจาก client เพื่อดึง kiosk list ปัจจุบัน (ใช้ในการแสดง UI)
    public async Task RequestKioskList() => await Clients.Caller.SendAsync("KioskList", GetKioskList());

    // kiosk เรียกเมธอดนี้ครั้งแรกเพื่อบอกว่ามาออนไลน์แล้ว
    public async Task<KioskStatusDto> RegisterKiosk(KioskStatusDto statusDto)
    {
        var findKiosk = _dbContext.Kiosk.Where(_k => _k.KioskCode == statusDto.KioskCode).FirstOrDefault();

		if (findKiosk == null)
            return new KioskStatusDto
            {
                KioskCode = statusDto.KioskCode,
                StatusCode = "error",
                StatusText = "❌ Kiosk ไม่มีในระบบ"
            };

        if (findKiosk.Inactive == 1)
            return new KioskStatusDto
            {
                KioskCode = statusDto.KioskCode,
                StatusCode = "error",
                StatusText = "❌ Kiosk นี้ยังไม่ได้เปิดใช้งาน กรุณาติดต่อเจ้าหน้าที่"
            };

        if (findKiosk.KioskToken != statusDto.KioskToken)
            return new KioskStatusDto
            {
                KioskCode = statusDto.KioskCode,
                StatusCode = "error",
                StatusText = "❌ Kiosk ไม่ถูกต้องกรุณาติดตั้งใหม่อีกครั้ง"
            };

        // Register สำเร็จ
        statusDto.StatusCode = KioskStatusConstant.Ready;
        statusDto.StatusText = KioskStatusConstant.ReadyText;
        statusDto.Timestamp = DateTime.Now;
        statusDto.LastUpdateTime = DateTime.Now;
        statusDto.HeartBeatInterval = HeartBeatInterval();

		_kioskConnections[statusDto.KioskCode] = statusDto;
        await Clients.All.SendAsync("KioskList", GetKioskList());
        return statusDto;
    }

    // ให้ client สมัครเข้ารับข้อมูลของ kiosk แบบเฉพาะเจาะจง (เช่นหน้าบ้านติดตาม kiosk เดียว)
    public async Task SubscribeKiosk(string KioskCode = "")
    {
        if (string.IsNullOrEmpty(KioskCode)) KioskCode = NSDXSession.Get<string>(NSDXSessionKey.KioskCode) ?? "";
        await Groups.AddToGroupAsync(Context.ConnectionId, $"kiosk:{KioskCode}");
    }

    private List<KioskStatusDto> GetKioskList() => _kioskConnections.Values.ToList();

    // ฟังก์ชันที่ตู้ kiosk ส่งข้อมูลบัตรมา แล้วกระจายข้อมูลให้กับ client ที่สมัครอยู่ใน group นั้น
    public async Task BroadcastKioskMessage(KioskStatusDto status, PersonalPhoto cardData)
    {
        Console.WriteLine("🔥 Broadcast KioskMessage: " + cardData.FullNameTH);
        _kioskConnections[status.KioskCode].LastUpdateTime = DateTime.Now; // อัปเดตเวลาออนไลน์ล่าสุด
        await Clients.Group($"kiosk:{status.KioskCode}").SendAsync("KioskMessage", cardData);
    }

    // kiosk ส่งสถานะปัจจุบัน (เช่น ready, card_detected ฯลฯ) ไปยังหน้าบ้าน
    public async Task BroadcastKioskStatus(KioskStatusDto status)
    {
        Console.WriteLine($"🔥 {status.Timestamp:HH:mm:ss} - [{status.KioskCode}] {status.StatusCode}: {status.StatusText}");
        _kioskConnections[status.KioskCode].LastUpdateTime = DateTime.Now; // บันทึกเวลาสุดท้ายที่ kiosk ยังออนไลน์
        await Clients.Group($"kiosk:{status.KioskCode}").SendAsync("KioskStatus", status);
    }

	public async Task<int> HeartBeat(string KioskId)
	{
		var find_kiosk = _kioskConnections.Where(x => x.Value.KioskId == KioskId);
		var interval = HeartBeatInterval();

		if (find_kiosk?.Any() ?? false)
		{
			try
			{
				var kioskId = uint.TryParse(KioskId, out var id) ? id : 0;
				if (kioskId == 0) return interval;

				var existing = _dbContext.KioskHeartbeat.FirstOrDefault(k => k.KioskId == kioskId);
				if (existing == null)
				{
					_dbContext.KioskHeartbeat.Add(new KioskHeartbeat { KioskId = kioskId, Lastupdate = DateTime.Now });
				}
				else
				{
					existing.Lastupdate = DateTime.Now;
					_dbContext.KioskHeartbeat.Update(existing);
				}

				await _dbContext.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"KioskHeartbeatWorker error: {ex.Message}");
				_dbContext.NsdxErrorLog.Add(new NsdxErrorLog { Message = ex.Message });
				await _dbContext.SaveChangesAsync();
			}
		}

		return interval;
	}

	// เรียกอัตโนมัติเมื่อ client (kiosk หรือ web) หลุดการเชื่อมต่อ
	// เรียกอัตโนมัติเมื่อมี client หลุด
	public override Task OnDisconnectedAsync(Exception? exception)
    {
        lock (_lock)
        {
            if (_connectionToKioskMap.TryGetValue(Context.ConnectionId, out var KioskCode))
            {
                // ❗ ไม่ลบออกจาก _kioskConnections ทันที เพื่อให้ฝั่ง web ยังเห็นว่าหลุด (Disconnected)
                Console.WriteLine($"⚠️ Kiosk [{KioskCode}] disconnected");
                _kioskConnections[KioskCode].LastUpdateTime = DateTime.Now;
                _connectionToKioskMap.Remove(Context.ConnectionId);

                // ถ้าคุณอยากลบทิ้งเลยจริง ๆ ให้ปลด comment ด้านล่าง:
                // _kioskConnections.Remove(kioskId);
            }
        }

        return base.OnDisconnectedAsync(exception);
    }
}