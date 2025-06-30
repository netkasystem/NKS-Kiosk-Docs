using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class IncidentRemainSummary
{
    public string? Id { get; set; }

    public long? NumberOfRemaining { get; set; }

    public string? Month1 { get; set; }

    public string? MonthName { get; set; }

    public DateOnly? Date { get; set; }
}
