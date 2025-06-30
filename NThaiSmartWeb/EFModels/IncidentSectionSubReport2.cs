using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class IncidentSectionSubReport2
{
    public string? Month { get; set; }

    public string? YMonth { get; set; }

    public string? MonthStr { get; set; }

    public string? YearStr { get; set; }

    public string CaseId { get; set; } = null!;

    public string? IncidentType { get; set; }

    public uint? SectionId { get; set; }

    public string? SectionTitle { get; set; }

    public int ResolvePass { get; set; }
}
