using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ModuleMappingView
{
    public uint ModuleId { get; set; }

    public string ModuleName { get; set; } = null!;

    public string? ServiceType { get; set; }

    public string? CaseLogType { get; set; }
}
