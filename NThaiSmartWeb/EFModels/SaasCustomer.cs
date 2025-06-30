using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SaasCustomer
{
    public uint Id { get; set; }

    public string Customercode { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Package { get; set; } = null!;

    public uint NumAgent { get; set; }

    public DateTime? ExpireDate { get; set; }

    public string? CompanyLogo { get; set; }

    public string? LoginBackground { get; set; }
}
