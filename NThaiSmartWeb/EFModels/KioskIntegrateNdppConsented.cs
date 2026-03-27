using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class KioskIntegrateNdppConsented
{
    public uint Id { get; set; }

    public uint KioskId { get; set; }

    public uint KioskIntegrateNdppId { get; set; }

    public string? CitizenId { get; set; }

    public string? FullnameTh { get; set; }

    public string? FullnameEn { get; set; }

    public string? Email { get; set; }

    /// <summary>
    /// purpose ที่เลือก/ไม่เลือก
    /// </summary>
    public string? PurposeOptionDetail { get; set; }

    public sbyte? Inactive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }
}

