using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Location
{
    public uint LocationId { get; set; }

    public uint OfficeId { get; set; }

    public string LocationTitle { get; set; } = null!;

    public string Building { get; set; } = null!;

    public uint Floor { get; set; }

    public string Room { get; set; } = null!;

    public string Row { get; set; } = null!;

    public string Rack { get; set; } = null!;

    public string Shelf { get; set; } = null!;

    public decimal Lat { get; set; }

    public decimal Lng { get; set; }

    public string Description { get; set; } = null!;

    public byte Inactive { get; set; }

    public byte LocationType { get; set; }
}
