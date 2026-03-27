using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Priority
{
    public uint PriorityId { get; set; }

    public string PriorityTitle { get; set; } = null!;

    public uint PrioritySequence { get; set; }

    public string Response { get; set; } = null!;

    public string Onsite { get; set; } = null!;

    public string Resolve { get; set; } = null!;

    public string Autoclose { get; set; } = null!;

    public byte _7x24 { get; set; }

    public string? Description { get; set; }

    public string Color { get; set; } = null!;

    public byte AllowDelete { get; set; }

    public virtual ICollection<PriorityLevel> PriorityLevel { get; set; } = new List<PriorityLevel>();
}

