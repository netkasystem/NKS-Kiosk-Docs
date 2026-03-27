using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Country
{
    public uint Id { get; set; }

    public string Country1 { get; set; } = null!;

    public string A2 { get; set; } = null!;

    public string A3 { get; set; } = null!;

    public string Region { get; set; } = null!;
}

