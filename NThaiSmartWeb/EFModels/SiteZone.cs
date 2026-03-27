using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SiteZone
{
    public uint SiteId { get; set; }

    public string SiteTitle { get; set; } = null!;

    public uint Zone { get; set; }
}

