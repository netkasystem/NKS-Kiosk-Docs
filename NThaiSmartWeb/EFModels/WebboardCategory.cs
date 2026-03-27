using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class WebboardCategory
{
    public uint Id { get; set; }

    public string? CategoryName { get; set; }

    public string? Description { get; set; }
}

