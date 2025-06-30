using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class MenuGroup
{
    public uint MenuGroupId { get; set; }

    public uint? MenuGroupParent { get; set; }

    public string MenuGroupName { get; set; } = null!;

    public string? MenuGroupDescription { get; set; }

    public string? MenuGroupIconClass { get; set; }

    public string? MenuGroupUrl { get; set; }

    public uint? MenuGroupValue { get; set; }

    public uint MenuGroupSequence { get; set; }

    public DateTime MenuGroupCreateDate { get; set; }

    public DateTime MenuGroupUpdateDate { get; set; }

    public virtual ICollection<MenuGroup> InverseMenuGroupParentNavigation { get; set; } = new List<MenuGroup>();

    public virtual MenuGroup? MenuGroupParentNavigation { get; set; }
}
