using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ProductKeyTrial
{
    public uint Id { get; set; }

    public string Ip { get; set; } = null!;

    public string Mac { get; set; } = null!;

    public DateOnly ExpiryDate { get; set; }

    public string Purpose { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public uint StaffId { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Company { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Province { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Zip { get; set; } = null!;
}

