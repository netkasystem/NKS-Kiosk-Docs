


public class KioskStatusDto
{
    public string KioskId { get; set; }
    public string StatusText { get; set; } // เช่น "📤 บัตรถูกถอดออกแล้ว"
    public string StatusCode { get; set; } // เช่น "card_removed", "ready", "reader_error"
    public DateTime Timestamp { get; set; }
}


