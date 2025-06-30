using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class IncidentSummaryByServiceEngineerReport9
{
    public string CaseTypeTitle { get; set; } = null!;

    public string? MonthStr { get; set; }

    public string? MonthYm { get; set; }

    public string? MonthM { get; set; }

    public string? EngineerName { get; set; }

    public string? Service { get; set; }

    public uint? CaseTypeId { get; set; }

    public long? IncidentCount { get; set; }

    public string? SummaryBy { get; set; }

    public DateTime? RequestedDate { get; set; }
}
