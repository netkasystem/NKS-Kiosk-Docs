using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ProductKeySale
{
    public uint Id { get; set; }

    public uint SaleProjectId { get; set; }

    public string Type { get; set; } = null!;

    public string Ip { get; set; } = null!;

    public string Mac { get; set; } = null!;

    public DateOnly ExpiryDate { get; set; }

    public DateTime Timestamp { get; set; }

    public string GeneratedBy { get; set; } = null!;

    public string Company { get; set; } = null!;

    public string? Email { get; set; }
}
