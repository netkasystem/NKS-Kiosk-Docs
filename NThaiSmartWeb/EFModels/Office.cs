using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Office
{
    public uint OfficeId { get; set; }

    public string OfficeTitle { get; set; } = null!;

    public string? Building { get; set; }

    public string? Level { get; set; }

    public string? Address { get; set; }

    public string? Street { get; set; }

    public int Tambol { get; set; }

    public int Amphur { get; set; }

    public int Province { get; set; }

    public uint Country { get; set; }

    public decimal Lat { get; set; }

    public decimal Lng { get; set; }

    public string? Zip { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? Web { get; set; }

    public string Hq { get; set; } = null!;
}
