using Microsoft.AspNetCore.SignalR;
using NThaiSmartWeb.EFModels;

public class CardReaderHub : Hub
{
    private readonly KioskContext _dbContext;

    public CardReaderHub(KioskContext dbContext)
    {
        _dbContext = dbContext;
    }

    // เก็บสถานะของแต่ละ kiosk โดยใช้ kioskId เป็น key
    private static readonly Dictionary<string, KioskStatusDto> _kioskConnections = new();

    // เก็บ mapping ระหว่าง connectionId → kioskId
    private static readonly Dictionary<string, string> _connectionToKioskMap = new();

    private static readonly object _lock = new(); // ใช้ lock ป้องกัน race condition

    // ให้สิทธิภายนอก (เช่น Worker) เข้าถึงข้อมูล kiosk status ปัจจุบัน
    public static Dictionary<string, KioskStatusDto> GetKioskStatusMap() => _kioskConnections;

    // รับคำขอจาก client เพื่อดึง kiosk list ปัจจุบัน (ใช้ในการแสดง UI)
    public async Task RequestKioskList() => await Clients.Caller.SendAsync("KioskList", GetKioskList());

    // kiosk เรียกเมธอดนี้ครั้งแรกเพื่อบอกว่ามาออนไลน์แล้ว

    public async Task<KioskStatusDto> RegisterKiosk(string KioskCode)
    {
        var chkActive = _dbContext.Kiosk.Where(_k => _k.KioskCode == KioskCode && _k.Inactive == 0).Any();

        if (!chkActive)
        {
            return new KioskStatusDto
            {
                KioskCode = KioskCode,
                StatusCode = "error",
                StatusText = "❌ Kiosk นี้ยังไม่ได้เปิดใช้งาน"
            };
        }

        // Register สำเร็จ
        var kioskDetail = new KioskStatusDto
        {
            KioskCode = KioskCode,
            StatusCode = "ready",
            StatusText = "✅ พร้อมใช้งาน",
            Timestamp = DateTime.Now,
            LastUpdateTime = DateTime.Now
        };

        _kioskConnections[KioskCode] = kioskDetail;
        await Clients.All.SendAsync("KioskList", GetKioskList());
        return kioskDetail;
    }

    // ให้ client สมัครเข้ารับข้อมูลของ kiosk แบบเฉพาะเจาะจง (เช่นหน้าบ้านติดตาม kiosk เดียว)
    public async Task SubscribeKiosk(string KioskCode = "")
    {
        if (string.IsNullOrEmpty(KioskCode)) KioskCode = NSDXSession.Get<string>(NSDXSessionKey.KioskCode) ?? "";
        await Groups.AddToGroupAsync(Context.ConnectionId, $"kiosk:{KioskCode}");
    }

    private List<KioskStatusDto> GetKioskList() => _kioskConnections.Values.ToList();

    // ฟังก์ชันที่ตู้ kiosk ส่งข้อมูลบัตรมา แล้วกระจายข้อมูลให้กับ client ที่สมัครอยู่ใน group นั้น
    public async Task BroadcastKioskMessage(string KioskCode, PersonalPhoto cardData)
    {
        Console.WriteLine("🔥 Broadcast KioskMessage: " + cardData.FullNameTH);
        _kioskConnections[KioskCode].LastUpdateTime = DateTime.Now; // อัปเดตเวลาออนไลน์ล่าสุด
        await Clients.Group($"kiosk:{KioskCode}").SendAsync("KioskMessage", cardData);
    }

    // kiosk ส่งสถานะปัจจุบัน (เช่น ready, card_detected ฯลฯ) ไปยังหน้าบ้าน
    public async Task BroadcastKioskStatus(KioskStatusDto status)
    {
        Console.WriteLine($"🔥 {status.Timestamp:HH:mm:ss} - [{status.KioskCode}] {status.StatusCode}: {status.StatusText}");
        _kioskConnections[status.KioskCode].LastUpdateTime = DateTime.Now; // บันทึกเวลาสุดท้ายที่ kiosk ยังออนไลน์
        await Clients.Group($"kiosk:{status.KioskCode}").SendAsync("KioskStatus", status);
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

                _connectionToKioskMap.Remove(Context.ConnectionId);

                // ถ้าคุณอยากลบทิ้งเลยจริง ๆ ให้ปลด comment ด้านล่าง:
                // _kioskConnections.Remove(kioskId);
            }
        }

        return base.OnDisconnectedAsync(exception);
    }
}