using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ImpactTime
{
    public uint Id { get; set; }

    public uint CaseId { get; set; }

    public string Task { get; set; } = null!;

    public string Duration { get; set; } = null!;
}
