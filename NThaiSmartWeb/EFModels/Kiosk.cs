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

    /// <summary>
    /// คำอธิบายเพิ่มเติม
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// วันที่สร้าง
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// วันที่อัพเดตล่าสุด
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    public string? KioskName { get; set; }

    public string? Address { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public string? ContactName { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactTel { get; set; }

    public byte? Inactive { get; set; }
}
