public class KioskStatusDto
{
    public string KioskCode { get; set; }
    public string StatusCode { get; set; }
    public string StatusText { get; set; }
    public DateTime Timestamp { get; set; }       // client ส่งมา

    // สถานะออนไลน์/ออฟไลน์
    public bool Connected => (DateTime.Now - LastUpdateTime).TotalMinutes < 3;
    public DateTime LastUpdateTime { get; set; }  // server บันทึก
}