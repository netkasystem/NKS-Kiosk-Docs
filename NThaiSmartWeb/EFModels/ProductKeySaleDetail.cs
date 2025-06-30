using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ProductKeySaleDetail
{
    public uint RefId { get; set; }

    public uint ProductId { get; set; }

    public string ProductKey { get; set; } = null!;
}
