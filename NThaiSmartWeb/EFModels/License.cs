using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class License
{
    public string ProductKey { get; set; } = null!;

    public string Product { get; set; } = null!;

    public byte Valid { get; set; }

    public string? Remark { get; set; }

    public string Total { get; set; } = null!;

    public string Used { get; set; } = null!;

    public string Available { get; set; } = null!;
}

