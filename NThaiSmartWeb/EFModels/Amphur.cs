using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Amphur
{
    public int AmphurId { get; set; }

    public string AmphurCode { get; set; } = null!;

    public string AmphurName { get; set; } = null!;

    public string AmphurNameEn { get; set; } = null!;

    public uint GeoId { get; set; }

    public int ProvinceId { get; set; }

    public uint CountryId { get; set; }
}
