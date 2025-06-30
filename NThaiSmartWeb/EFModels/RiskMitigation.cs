using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class RiskMitigation
{
    public uint Id { get; set; }

    public string Task { get; set; } = null!;

    public string Description { get; set; } = null!;

    public uint CaseId { get; set; }
}
