using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Supplier
{
    public uint SupplierId { get; set; }

    public string SupplierCode { get; set; } = null!;

    public string SupplierName { get; set; } = null!;

    public string? Building { get; set; }

    public string? Level { get; set; }

    public string? Address { get; set; }

    public string? Street { get; set; }

    public uint? Tambol { get; set; }

    public uint? Amphur { get; set; }

    public uint? Province { get; set; }

    public uint Country { get; set; }

    public decimal Lat { get; set; }

    public decimal Lng { get; set; }

    public string? Zip { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? Web { get; set; }

    public byte Inactive { get; set; }
}
