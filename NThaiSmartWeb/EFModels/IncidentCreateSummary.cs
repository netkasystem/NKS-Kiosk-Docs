using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class IncidentCreateSummary
{
    public long? NumberOfCreatedcase { get; set; }

    public string? Id { get; set; }

    public string? MonthName { get; set; }

    public DateOnly? Date { get; set; }
}
