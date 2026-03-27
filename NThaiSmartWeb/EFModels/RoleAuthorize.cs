using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class RoleAuthorize
{
    public uint Id { get; set; }

    public string Type { get; set; } = null!;

    public string ControlId { get; set; } = null!;
}

