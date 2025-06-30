public class KioskStatusDto
{
    public string KioskId { get; set; }
    public string StatusCode { get; set; }
    public string StatusText { get; set; }
    public DateTime Timestamp { get; set; }       // client ส่งมา
    public DateTime LastUpdateTime { get; set; }  // server บันทึก

    // สถานะออนไลน์/ออฟไลน์
    public bool Connected => (DateTime.Now - LastUpdateTime).TotalMinutes < 3;
}