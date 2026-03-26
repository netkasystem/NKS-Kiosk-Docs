public class EnrollRequest
{
    public string DeviceId { get; set; } = "";
    public string Hostname { get; set; } = "";
    public string OsName { get; set; } = "";
    public string OsVersion { get; set; } = "";
    public string Kernel { get; set; } = "";
    public string AppVersion { get; set; } = "";
    public string IpAddress { get; set; } = "";
    public string MacAddress { get; set; } = "";
    public string ProductUuid { get; set; } = "";
    public string CpuModel { get; set; } = "";
    public int RamMb { get; set; }
    public int DiskGb { get; set; }
    public string KioskUser { get; set; } = "";
    public string Timezone { get; set; } = "";
    public string Locale { get; set; } = "";
    public DateTime EnrolledAt { get; set; }
}