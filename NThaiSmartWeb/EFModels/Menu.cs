using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Menu
{
    public uint MenuId { get; set; }

    public string MenuName { get; set; } = null!;

    public string? MenuDescription { get; set; }

    public string? MenuIconClass { get; set; }

    public uint MenuSequence { get; set; }

    public string MenuUrl { get; set; } = null!;

    public ulong MenuNewFlag { get; set; }

    public DateTime MenuCreateDate { get; set; }

    public DateTime MenuUpdateDate { get; set; }

    public uint? ParentMenuId { get; set; }

    public uint MenuGroupId { get; set; }

    public uint? ModuleId { get; set; }

    public virtual ICollection<Menu> InverseParentMenu { get; set; } = new List<Menu>();

    public virtual MenuGroup MenuGroup { get; set; } = null!;

    public virtual ICollection<MenuTutorialMapping> MenuTutorialMapping { get; set; } = new List<MenuTutorialMapping>();

    public virtual Menu? ParentMenu { get; set; }
}
