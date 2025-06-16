using Microsoft.AspNetCore.SignalR;

namespace N_ThaiSmart_Web.Hubs
{
    public class CardReaderHub : Hub
    {
        private static Dictionary<string, KioskStatusDto> _kioskConnections = new();

        public static Dictionary<string, KioskStatusDto> GetKioskStatusMap() => _kioskConnections;

        public async Task SubscribeKiosk(string kioskId) => await Groups.AddToGroupAsync(Context.ConnectionId, $"kiosk:{kioskId}");

        // ส่งข้อมูลบัตรไปให้หน้าบ้าน
        public async Task BroadcastKioskMessage(string kioskId, PersonalPhoto cardData)
        {
            Console.WriteLine("🔥 Broadcast KioskMessage: " + cardData.FullNameTH);
            await Clients.Group($"kiosk:{kioskId}").SendAsync("KioskMessage", cardData);
        }

        public async Task BroadcastKioskStatus(KioskStatusDto status)
        {
            Console.WriteLine($"🔥 {status.Timestamp:HH:mm:ss} - [{status.KioskId}] {status.StatusCode}: {status.StatusText}");
            status.Timestamp = DateTime.Now;
            // อัปเดตสถานะ Kiosk
            _kioskConnections[status.KioskId] = status;
            // ส่งไปให้ทุก Client
            await Clients.All.SendAsync("KioskStatus", status);
        }

        public async Task RegisterKiosk(string kioskId)
        {
            var status = new KioskStatusDto { KioskId = kioskId, StatusCode = "ready", StatusText = "✅ พร้อมใช้งาน", Timestamp = DateTime.Now };
            _kioskConnections[kioskId] = status;
            await Clients.All.SendAsync("KioskList", GetKioskList());
        }

        public async Task RequestKioskList() => await Clients.Caller.SendAsync("KioskList", GetKioskList());

        private List<object> GetKioskList() => _kioskConnections.Select(_k => _k.Value).ToList<object>();

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            if (_kioskConnections.TryGetValue(Context.ConnectionId, out var kioskId))
            {
                _kioskConnections.Remove(Context.ConnectionId);
            }
            return base.OnDisconnectedAsync(exception);
        }
    }
}