using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class MenuApiPathAnonymous
{
    public uint Id { get; set; }

    public string Path { get; set; } = null!;

    public uint? ModuleId { get; set; }

    public virtual Module? Module { get; set; }
}

