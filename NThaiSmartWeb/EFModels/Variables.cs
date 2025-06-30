using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Variables
{
    public string Name { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Value { get; set; } = null!;

    public uint OrderNum { get; set; }

    public byte Hidden { get; set; }

    public string Description { get; set; } = null!;

    public string Datatype { get; set; } = null!;
}
