using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ImLog
{
    public string Date { get; set; } = null!;

    public string Time { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string CreateBy { get; set; } = null!;
}

