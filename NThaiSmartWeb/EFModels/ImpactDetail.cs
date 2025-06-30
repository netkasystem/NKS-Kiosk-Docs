using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ImpactDetail
{
    public uint Id { get; set; }

    public uint CaseId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte ServiceInterruption { get; set; }

    public string AffectedParties { get; set; } = null!;
}
