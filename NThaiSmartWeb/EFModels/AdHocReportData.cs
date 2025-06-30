using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class AdHocReportData
{
    public uint Id { get; set; }

    public uint ProfileId { get; set; }

    public string Value { get; set; } = null!;
}
