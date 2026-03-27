using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class NsdxErrorLog
{
    public uint Id { get; set; }

    public string Message { get; set; } = null!;

    public string ErrorPage { get; set; } = null!;

    public DateTime ErrorTime { get; set; }
}

