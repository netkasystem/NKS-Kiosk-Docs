using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class IncidentRabbitmq
{
    public uint Id { get; set; }

    public string Actions { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? Reftype { get; set; }

    public string Refid { get; set; } = null!;

    public DateTime? CreatedDt { get; set; }

    public DateTime? UpdatedDt { get; set; }
}
