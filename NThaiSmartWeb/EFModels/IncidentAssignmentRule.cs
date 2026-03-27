using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class IncidentAssignmentRule
{
    public uint Id { get; set; }

    public uint ServiceCatalogId { get; set; }

    public uint CaseCategoryId { get; set; }

    public uint CaseSubCategoryId { get; set; }

    public uint TeamId { get; set; }

    public uint EngineerId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime UpdatedDate { get; set; }
}

