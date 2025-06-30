using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class IncidentCountByTimeReport14
{
    public string? YMonth { get; set; }

    public string? StrMonth { get; set; }

    public string? MonthStr { get; set; }

    public string? TimeRank { get; set; }

    public string? YMonthTimeRank { get; set; }

    public long IncidentCount { get; set; }
}
