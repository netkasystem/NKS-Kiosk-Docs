using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ClosureType
{
    public uint ClosureTypeId { get; set; }

    public string ClosureTypeTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte Inactive { get; set; }
}
