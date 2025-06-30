using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class PrivilegeDetail
{
    public uint LevelId { get; set; }

    public string LevelName { get; set; } = null!;

    public uint MenuId { get; set; }

    public string MenuName { get; set; } = null!;

    public string MenuUrl { get; set; } = null!;

    public uint? ModuleId { get; set; }

    public uint? PrivilegeId { get; set; }
}
