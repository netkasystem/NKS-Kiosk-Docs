using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Region
{
    public uint RegionId { get; set; }

    public string RegionTitle { get; set; } = null!;

    public string RegionDescription { get; set; } = null!;

    public uint CustomerId { get; set; }

    public byte Inactive { get; set; }
}
