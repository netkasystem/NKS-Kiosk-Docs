using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class MenuTutorialMapping
{
    public uint Id { get; set; }

    public uint MenuId { get; set; }

    public string Filename { get; set; } = null!;

    public virtual Menu Menu { get; set; } = null!;
}
