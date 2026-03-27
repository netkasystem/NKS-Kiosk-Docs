using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class MenuUserRouting
{
    public uint Id { get; set; }

    public uint MenuId { get; set; }

    public string Username { get; set; } = null!;

    public uint Count { get; set; }
}

