using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ImpactSow
{
    public uint Id { get; set; }

    public uint CaseId { get; set; }

    public string Item { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string SowId { get; set; } = null!;

    public string Duration { get; set; } = null!;
}
