using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class AdHocReportTimePeriod
{
    public uint Id { get; set; }

    /// <summary>
    /// days
    /// </summary>
    public uint Duration { get; set; }

    public string Label { get; set; } = null!;
}

