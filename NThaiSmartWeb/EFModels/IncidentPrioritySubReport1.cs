using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class IncidentPrioritySubReport1
{
    public string? IncidentType { get; set; }

    public string? AssociateFromSd { get; set; }

    public string? AssociateToIm { get; set; }

    public string ParentType { get; set; } = null!;

    public string Parent { get; set; } = null!;

    public string CaseId { get; set; } = null!;

    public string Child { get; set; } = null!;

    public string ChildType { get; set; } = null!;

    public string? Month { get; set; }

    public string? YMonth { get; set; }

    public string? MonthStr { get; set; }

    public string? YearStr { get; set; }

    public uint PriorityId { get; set; }

    public string? PriorityTitle { get; set; }

    public int ResolvePass { get; set; }
}
