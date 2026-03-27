using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CategoryIcon
{
    public uint Id { get; set; }

    public uint CaseCategoryId { get; set; }

    public uint CaseSubCategoryId { get; set; }

    public string ImageName { get; set; } = null!;
}

