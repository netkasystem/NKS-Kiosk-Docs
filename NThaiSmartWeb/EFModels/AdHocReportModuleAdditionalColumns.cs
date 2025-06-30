using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class AdHocReportModuleAdditionalColumns
{
    public uint Id { get; set; }

    public string Module { get; set; } = null!;

    public string LookUpTb { get; set; } = null!;

    public uint ModuleId { get; set; }

    public string SqlGetCaseidByUser { get; set; } = null!;
}
