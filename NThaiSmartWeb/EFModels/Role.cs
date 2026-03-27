using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Role
{
    public uint RoleId { get; set; }

    public string RoleTitle { get; set; } = null!;
}

