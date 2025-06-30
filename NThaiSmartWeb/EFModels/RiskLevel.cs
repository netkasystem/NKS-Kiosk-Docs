using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class RiskLevel
{
    public uint Id { get; set; }

    public uint ImpactId { get; set; }

    public uint ProbabilityId { get; set; }

    public uint RiskLevel1 { get; set; }

    public string Description { get; set; } = null!;

    public string GridCode { get; set; } = null!;
}
