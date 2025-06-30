using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Sla
{
    public uint SlaId { get; set; }

    public string? SlaCode { get; set; }

    public string? SlaTitle { get; set; }

    public string? Description { get; set; }
}
