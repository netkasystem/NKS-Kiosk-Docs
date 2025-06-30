using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CaseSubCategory
{
    public uint CaseSubCategoryId { get; set; }

    public string CaseSubCategoryTitle { get; set; } = null!;

    public uint CaseCategoryId { get; set; }

    public string Description { get; set; } = null!;

    public byte Inactive { get; set; }
}
