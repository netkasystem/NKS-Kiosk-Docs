using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ResolutionType
{
    public uint ResolutionTypeId { get; set; }

    public string ResolutionTypeTitle { get; set; } = null!;

    public uint ResolutionCategoryId { get; set; }

    public uint RootCauseId { get; set; }

    public byte Inactive { get; set; }
}

