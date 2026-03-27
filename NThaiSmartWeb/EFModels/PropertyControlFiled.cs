using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class PropertyControlFiled
{
    public uint Id { get; set; }

    public string ControlType { get; set; } = null!;

    public string Description { get; set; } = null!;
}

