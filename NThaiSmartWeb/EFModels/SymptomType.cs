using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SymptomType
{
    public uint SymptomTypeId { get; set; }

    public string SymptomTypeTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public uint Inactive { get; set; }
}

