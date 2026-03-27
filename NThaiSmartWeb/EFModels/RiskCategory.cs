using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class RiskCategory
{
    public uint RiskCategoryId { get; set; }

    public string RiskCategoryTitle { get; set; } = null!;

    public string Description { get; set; } = null!;
}

