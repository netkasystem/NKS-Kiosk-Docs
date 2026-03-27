using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Address
{
    public string AddressId { get; set; } = null!;

    public string DescriptionThai { get; set; } = null!;

    public string DescriptionEnglish { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string? Code { get; set; }
}

