using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Vendor
{
    public uint VendorId { get; set; }

    public string VendorCode { get; set; } = null!;

    public string VendorName { get; set; } = null!;
}
