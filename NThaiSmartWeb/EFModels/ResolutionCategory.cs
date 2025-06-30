using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ResolutionCategory
{
    public uint ResolutionCategoryId { get; set; }

    public string ResolutionCategoryTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte Inactive { get; set; }
}
