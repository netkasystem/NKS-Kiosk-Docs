using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class MenuChatbot
{
    public string Menu { get; set; } = null!;

    public string MenuId { get; set; } = null!;

    public string Parent { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string RequiremenId { get; set; } = null!;
}
