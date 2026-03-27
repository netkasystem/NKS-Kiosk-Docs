using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CaseCategory
{
    public uint CaseCategoryId { get; set; }

    public string CaseCategoryTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte Inactive { get; set; }

    public uint CaseTypeId { get; set; }
}

