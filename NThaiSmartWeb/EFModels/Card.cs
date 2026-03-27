using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Card
{
    public uint CardId { get; set; }

    public string CardTitle { get; set; } = null!;

    public string CardDescription { get; set; } = null!;

    public string Remark { get; set; } = null!;

    public string Inactive { get; set; } = null!;
}

