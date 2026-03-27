using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class NsdxResetFactoryLog
{
    public uint Id { get; set; }

    public DateTime DateTime { get; set; }

    public string Username { get; set; } = null!;

    public byte DeleteFlag { get; set; }

    public uint IsProcess { get; set; }
}

