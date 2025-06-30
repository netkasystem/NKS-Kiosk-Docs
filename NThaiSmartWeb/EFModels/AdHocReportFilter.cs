using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class AdHocReportFilter
{
    public uint Id { get; set; }

    public string Operand { get; set; } = null!;

    public string Value { get; set; } = null!;

    public uint ProfileId { get; set; }

    public string FieldName { get; set; } = null!;

    public string Operand2 { get; set; } = null!;

    public string SessionId { get; set; } = null!;
}
