using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SupplierContact
{
    public uint SupplierContactId { get; set; }

    public uint SupplierId { get; set; }

    public string ContactName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string? Phone { get; set; }

    public string Email { get; set; } = null!;

    public string Remark { get; set; } = null!;

    public byte Inactive { get; set; }

    public string? ProfileImage { get; set; }
}
