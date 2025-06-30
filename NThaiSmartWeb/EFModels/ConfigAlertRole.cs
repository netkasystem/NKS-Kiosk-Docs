using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ConfigAlertRole
{
    public uint Id { get; set; }

    public uint ModuleId { get; set; }

    public string RoleName { get; set; } = null!;

    public string QueryStaff { get; set; } = null!;
}
