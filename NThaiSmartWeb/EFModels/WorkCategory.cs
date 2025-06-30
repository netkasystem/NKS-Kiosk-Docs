using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class WorkCategory
{
    public uint WorkCategoryId { get; set; }

    public string WorkCategoryTitle { get; set; } = null!;
}
