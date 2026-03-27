using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Collaboration
{
    public uint Id { get; set; }

    public string Room { get; set; } = null!;

    public DateTime Datetime { get; set; }

    public string Message { get; set; } = null!;

    public string? Attach { get; set; }

    public uint Isdelete { get; set; }

    public uint Staffid { get; set; }
}

