using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Probability
{
    public uint Id { get; set; }

    public string ProbabilityTitle { get; set; } = null!;

    public string Description { get; set; } = null!;
}
