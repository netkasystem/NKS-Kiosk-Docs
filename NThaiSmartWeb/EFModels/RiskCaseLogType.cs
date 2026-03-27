using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class RiskCaseLogType
{
    public uint RiskCaseLogTypeId { get; set; }

    public string RiskCaseLogTypeTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public uint CaseLogCategoryId { get; set; }
}

