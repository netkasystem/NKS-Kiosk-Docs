using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class KioskContract
{
    public uint Id { get; set; }

    /// <summary>
    /// เลขที่สัญญา
    /// </summary>
    public string ContractCode { get; set; } = null!;

    public string? ContractName { get; set; }

    /// <summary>
    /// คำอธิบายเพิ่มเติม
    /// </summary>
    public string? Description { get; set; }

    public string? ContactName { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactTel { get; set; }

    public byte? Inactive { get; set; }

    /// <summary>
    /// วันที่สร้าง
    /// </summary>
    public DateTime CreatedDate { get; set; }

    public uint CreatedBy { get; set; }

    /// <summary>
    /// วันที่อัพเดตล่าสุด
    /// </summary>
    public DateTime UpdatedDate { get; set; }

    public uint UpdatedBy { get; set; }
}

