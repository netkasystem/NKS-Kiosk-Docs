using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Geography
{
    public uint GeoId { get; set; }

    public string GeoName { get; set; } = null!;

    public uint GeoSequence { get; set; }
}
