using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Province
{
    public int ProvinceId { get; set; }

    public string ProvinceCode { get; set; } = null!;

    public string ProvinceName { get; set; } = null!;

    public string ProvinceNameEn { get; set; } = null!;

    public uint GeoId { get; set; }

    public uint CountryId { get; set; }
}
