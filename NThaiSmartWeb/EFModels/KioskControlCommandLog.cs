using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class KioskControlCommandLog
{
    public uint Id { get; set; }

    public uint KioskId { get; set; }

    public uint CommandId { get; set; }

    public string? Args { get; set; }

    public string? Status { get; set; }

    public DateTime? ExecutedAt { get; set; }

    public DateTime CreatedAt { get; set; }
}

