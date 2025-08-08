using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class KioskView
{
    public uint? Id { get; set; }

    /// <summary>
    /// รหัสเครื่อง Kiosk
    /// </summary>
    public string? KioskCode { get; set; }

    public string? KioskName { get; set; }

    /// <summary>
    /// คำอธิบายเพิ่มเติม
    /// </summary>
    public string? Description { get; set; }

    public string? Address { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public string? OnsiteContactName { get; set; }

    public string? OnsiteContactEmail { get; set; }

    public string? OnsiteContactTel { get; set; }

    public byte? Inactive { get; set; }

    /// <summary>
    /// วันที่สร้าง
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// วันที่อัพเดตล่าสุด
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public DateTime? Lastupdate { get; set; }

    public long? MinAgo { get; set; }

    public uint? ContractId { get; set; }

    /// <summary>
    /// เลขที่สัญญา
    /// </summary>
    public string? ContractCode { get; set; }

    public string? ContractName { get; set; }

    public string? ContactNameOfContract { get; set; }

    public string? ContactEmailOfContract { get; set; }

    public string? ContactTelOfContract { get; set; }

    public string? ProvinceName { get; set; }

    public string? HealthTitle { get; set; }

    public string? BackgroundColor { get; set; }

    public string? FontColor { get; set; }

    public string CustomFormValue { get; set; } = null!;

    public DateOnly Today { get; set; }
}
