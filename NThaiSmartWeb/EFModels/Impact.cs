using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Impact
{
    public uint ImpactId { get; set; }

    public string ImpactTitle { get; set; } = null!;

    public uint ImpactSequence { get; set; }

    public string Description { get; set; } = null!;

    public ushort AllowDelete { get; set; }

    public virtual ICollection<PriorityLevel> PriorityLevel { get; set; } = new List<PriorityLevel>();
}

