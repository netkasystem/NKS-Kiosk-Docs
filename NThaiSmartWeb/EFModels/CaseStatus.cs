using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CaseStatus
{
    public uint CaseStatusId { get; set; }

    public string CaseStatusTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Color { get; set; } = null!;
}
