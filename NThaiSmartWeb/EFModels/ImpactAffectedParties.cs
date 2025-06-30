using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ImpactAffectedParties
{
    public uint Id { get; set; }

    public uint CaseId { get; set; }

    public string Name { get; set; } = null!;

    public string Organization { get; set; } = null!;

    public string Description { get; set; } = null!;
}
