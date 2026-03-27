using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class AdminEditLog
{
    public uint Id { get; set; }

    public string Date { get; set; } = null!;

    public string Time { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Page { get; set; } = null!;
}

