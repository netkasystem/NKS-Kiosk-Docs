using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CustomerContact
{
    public uint CustomerId { get; set; }

    public string? Symbol { get; set; }

    public string? CustomerName { get; set; }

    public string ContactName { get; set; } = null!;

    public string ContactNameEn { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Email2 { get; set; } = null!;

    public uint Inactive { get; set; }

    public string Remark { get; set; } = null!;
}

