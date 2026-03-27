using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Module
{
    public uint ModuleId { get; set; }

    public string ModuleName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public uint MenuId { get; set; }

    public uint LookupAssociated { get; set; }

    public uint LookupLogType { get; set; }

    public uint LookupTbStatus { get; set; }

    public string? DataView { get; set; }

    public uint LandingMenuId { get; set; }

    public uint LookupDashboard { get; set; }

    public uint LookupColumndate { get; set; }

    public uint MenuGroupId { get; set; }

    public uint ModuleSequence { get; set; }

    public string SqlDetailByCaseid { get; set; } = null!;

    public virtual ICollection<MenuApiPathAnonymous> MenuApiPathAnonymous { get; set; } = new List<MenuApiPathAnonymous>();
}

