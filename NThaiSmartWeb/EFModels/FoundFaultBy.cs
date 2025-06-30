using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class FoundFaultBy
{
    public uint FoundFaultById { get; set; }

    public string FoundFaultByTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public uint Inactive { get; set; }
}
