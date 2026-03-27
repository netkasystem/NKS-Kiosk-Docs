using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Node
{
    public uint NodeId { get; set; }

    public string NodeTitle { get; set; } = null!;

    public string NodeDescription { get; set; } = null!;

    public string Remark { get; set; } = null!;

    public uint Inactive { get; set; }
}

