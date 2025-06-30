using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Urgency
{
    public uint UrgencyId { get; set; }

    public string UrgencyTitle { get; set; } = null!;

    public uint UrgencySequence { get; set; }

    public string ReviewDuration { get; set; } = null!;

    public string AnalyzeDuration { get; set; } = null!;

    public string ApproveDuration { get; set; } = null!;

    public string Description { get; set; } = null!;

    public ushort AllowDelete { get; set; }

    public virtual ICollection<PriorityLevel> PriorityLevel { get; set; } = new List<PriorityLevel>();
}
