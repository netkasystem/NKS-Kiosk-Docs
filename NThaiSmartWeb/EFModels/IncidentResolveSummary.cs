using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class IncidentResolveSummary
{
    public long? NumberOfResolvedcase { get; set; }

    public string? Id { get; set; }

    public string? Month1 { get; set; }

    public string? MonthName { get; set; }

    public DateOnly? Date { get; set; }
}
