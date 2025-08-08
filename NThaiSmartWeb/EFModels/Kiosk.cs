using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Kiosk
{
    public uint Id { get; set; }

    /// <summary>
    /// รหัสเครื่อง Kiosk
    /// </summary>
    public string KioskCode { get; set; } = null!;

    public string? KioskName { get; set; }

    /// <summary>
    /// คำอธิบายเพิ่มเติม
    /// </summary>
    public string? Description { get; set; }

    public string? Address { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public string? ContactName { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactTel { get; set; }

    public byte? Inactive { get; set; }

    /// <summary>
    /// วันที่สร้าง
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// วันที่อัพเดตล่าสุด
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Permanent kiosk token for SSO / agent auth
    /// </summary>
    public string? KioskToken { get; set; }

    public string KioskImage { get; set; } = null!;

    public int ProvinceId { get; set; }

    public string? SerialNumber { get; set; }

    public uint? ContractId { get; set; }

    public uint? RegionId { get; set; }
}
