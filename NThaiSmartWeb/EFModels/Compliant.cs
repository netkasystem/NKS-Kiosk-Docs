using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Compliant
{
    public uint Id { get; set; }

    public string Title { get; set; } = null!;

    public string Message { get; set; } = null!;

    public uint Sequence { get; set; }
}
