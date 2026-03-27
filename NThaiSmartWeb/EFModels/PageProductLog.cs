using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class PageProductLog
{
    public uint Id { get; set; }

    public string Date { get; set; } = null!;

    public string Time { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string ChangeDesc { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public byte UpdatedStatus { get; set; }
}

