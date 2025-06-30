using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class IncidentResolution
{
    public uint Id { get; set; }

    public string? CreatedDate { get; set; }

    public string CaseId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string CaseStatusTitle { get; set; } = null!;

    public string ServiceTypeTitle { get; set; } = null!;

    public string CaseCategoryTitle { get; set; } = null!;

    public string CaseSubCategoryTitle { get; set; } = null!;

    public string? Engineer { get; set; }

    public string OfficeTitle { get; set; } = null!;

    public string TeamTitle { get; set; } = null!;

    public string SectionTitle { get; set; } = null!;

    public string DepartmentTitle { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string ContractTitle { get; set; } = null!;

    public string SiteTitle { get; set; } = null!;

    public string RegionTitle { get; set; } = null!;

    public string Contact { get; set; } = null!;

    public string PriorityTitle { get; set; } = null!;

    public uint ResolutionTypeId { get; set; }

    public string ResolutionTypeTitle { get; set; } = null!;

    public string? _7x24 { get; set; }

    public string CaseTypeTitle { get; set; } = null!;

    public string? LoggedBy { get; set; }
}
