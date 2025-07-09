using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class NsdFunction
{
    public uint Id { get; set; }

    public string FunctionName { get; set; } = null!;

    public string FunctionDescription { get; set; } = null!;
}
