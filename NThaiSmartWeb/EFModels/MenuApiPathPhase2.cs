using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class MenuApiPathPhase2
{
    public uint Id { get; set; }

    public string Path { get; set; } = null!;

    public uint? ModuleId { get; set; }
}
