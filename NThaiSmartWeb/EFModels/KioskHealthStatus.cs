using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class KioskHealthStatus
{
    public uint Id { get; set; }

    public uint LassMin { get; set; }

    public string HealthTitle { get; set; } = null!;

    public string BackgroundColor { get; set; } = null!;

    public string FontColor { get; set; } = null!;
}

