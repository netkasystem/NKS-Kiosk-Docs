using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class KioskIntegrateNdpp
{
    public uint Id { get; set; }

    /// <summary>
    /// ชื่อบริการ
    /// </summary>
    public string ServiceName { get; set; } = null!;

    /// <summary>
    /// รายละเอียดบริการ
    /// </summary>
    public string? ServiceDescription { get; set; }

    public string? NdppPreferenceUrl { get; set; }

    /// <summary>
    /// วันที่เริ่ม เปิดบริการ
    /// </summary>
    public DateTime ServiceStartDate { get; set; }

    /// <summary>
    /// วันที่เริ่ม ปิดให้บริการ
    /// </summary>
    public DateTime ServiceStopDate { get; set; }

    public string ServiceImage { get; set; } = null!;

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
