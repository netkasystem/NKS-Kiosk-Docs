using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Risk
{
    public int RiskId { get; set; }

    public string RiskTitle { get; set; } = null!;

    public int MinScore { get; set; }

    public int MaxScore { get; set; }

    public string Color { get; set; } = null!;
}
