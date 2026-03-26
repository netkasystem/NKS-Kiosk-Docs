using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class KioskIntegrateNdppConsentMapping
{
    public uint Id { get; set; }

    public uint KioskId { get; set; }

    public uint KioskIntegrateNdppId { get; set; }

    public sbyte? Inactive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }
}

