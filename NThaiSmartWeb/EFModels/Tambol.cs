using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Tambol
{
    public int TambolId { get; set; }

    public string TambolCode { get; set; } = null!;

    public string TambolName { get; set; } = null!;

    public string TambolNameEn { get; set; } = null!;

    public int AmphurId { get; set; }

    public int ProvinceId { get; set; }

    public uint GeoId { get; set; }

    public uint CountryId { get; set; }
}

