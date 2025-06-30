using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class IncidentServiceReport
{
    public uint CaseId { get; set; }

    public string RootCauseDetail { get; set; } = null!;

    public string SolvingMethod { get; set; } = null!;

    public string DiagnosedByCustomer { get; set; } = null!;
}
