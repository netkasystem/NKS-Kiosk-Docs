using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class IncidentTemplate
{
    public uint Id { get; set; }

    public string TemplateName { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string CaseDescription { get; set; } = null!;

    public uint CaseCategoryId { get; set; }

    public uint CaseSubCategoryId { get; set; }

    public uint PriorityId { get; set; }

    public uint TierId { get; set; }

    public string Remark { get; set; } = null!;

    public uint ImpactId { get; set; }

    public uint UrgencyId { get; set; }

    public uint CaseTypeId { get; set; }

    public uint SymptomTypeId { get; set; }

    public uint EngineerId { get; set; }

    public string IconPath { get; set; } = null!;

    public uint SectionId { get; set; }

    public uint DepartmentId { get; set; }

    public uint ShareUser { get; set; }

    public uint ShareEngineer { get; set; }

    public uint Inactive { get; set; }

    public string Filelink { get; set; } = null!;

    public string Password { get; set; } = null!;

    public uint TeamId { get; set; }

    public uint ServiceTypeId { get; set; }
}

