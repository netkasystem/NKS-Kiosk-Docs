using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class TypeOfService
{
    public uint TypeOfServiceId { get; set; }

    public string TypeOfServiceTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string IsSlaEffect { get; set; } = null!;

    public uint Inactive { get; set; }
}
