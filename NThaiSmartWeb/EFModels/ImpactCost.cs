using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ImpactCost
{
    public uint Id { get; set; }

    public uint CaseId { get; set; }

    public string Item { get; set; } = null!;

    public string Unit { get; set; } = null!;

    public string TotalCost { get; set; } = null!;

    public uint Quantity { get; set; }

    public uint UnitCost { get; set; }
}
