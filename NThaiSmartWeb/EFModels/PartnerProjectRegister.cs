using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class PartnerProjectRegister
{
    public uint? ProjectId { get; set; }

    public string? ProjectName { get; set; }

    public string? Email { get; set; }
}
