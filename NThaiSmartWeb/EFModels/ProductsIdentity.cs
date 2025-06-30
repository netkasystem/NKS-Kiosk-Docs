using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ProductsIdentity
{
    public string SysobjectId { get; set; } = null!;

    public string Product { get; set; } = null!;

    public string? ProductType { get; set; }

    public string ProductDescription { get; set; } = null!;

    public ushort ProductCategoryId { get; set; }

    public string CpuOid { get; set; } = null!;

    public string MemSizeOid { get; set; } = null!;

    public string MemUsedOid { get; set; } = null!;

    public string MemFreeOid { get; set; } = null!;

    public string MemPercentageOid { get; set; } = null!;

    public string CpuName { get; set; } = null!;

    public byte Inactive { get; set; }
}
