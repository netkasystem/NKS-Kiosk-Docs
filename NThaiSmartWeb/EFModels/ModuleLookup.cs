using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ModuleLookup
{
    public uint ModuleLookupId { get; set; }

    public string TableName { get; set; } = null!;

    public string TableRef { get; set; } = null!;

    public string TableTitle { get; set; } = null!;

    public string TableCondition { get; set; } = null!;
}
