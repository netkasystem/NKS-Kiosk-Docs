using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class PriorityLevel
{
    public uint Id { get; set; }

    public uint ImpactId { get; set; }

    public uint UrgencyId { get; set; }

    public uint PriorityId { get; set; }

    public string Description { get; set; } = null!;

    public string GridCode { get; set; } = null!;

    public virtual Impact Impact { get; set; } = null!;

    public virtual Priority Priority { get; set; } = null!;

    public virtual Urgency Urgency { get; set; } = null!;
}
