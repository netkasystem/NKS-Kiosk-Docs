using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SlaDetail
{
    public uint SlaDetailId { get; set; }

    public uint SlaId { get; set; }

    public uint PriorityId { get; set; }

    public string Response { get; set; } = null!;

    public string Onsite { get; set; } = null!;

    public string Resolve { get; set; } = null!;

    public string Autoclose { get; set; } = null!;

    public uint _7x24 { get; set; }
}
