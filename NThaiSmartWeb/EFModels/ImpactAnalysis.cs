using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ImpactAnalysis
{
    public uint Id { get; set; }

    public uint CaseId { get; set; }

    public uint IsAnalysis { get; set; }

    public string Comment { get; set; } = null!;
}
