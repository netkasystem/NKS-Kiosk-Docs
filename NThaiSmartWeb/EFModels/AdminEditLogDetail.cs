using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class AdminEditLogDetail
{
    public uint Id { get; set; }

    public uint LogId { get; set; }

    public string TableName { get; set; } = null!;

    public string FieldName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string OldValue { get; set; } = null!;

    public string NewValue { get; set; } = null!;
}
