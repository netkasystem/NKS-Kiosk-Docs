using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Sector
{
    public uint SectorId { get; set; }

    public string SectorTitle { get; set; } = null!;

    public string Description { get; set; } = null!;
}

