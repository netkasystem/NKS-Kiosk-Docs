using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CaseTypeCustom
{
    public uint Id { get; set; }

    public string FieldName { get; set; } = null!;

    public string LabelName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte Inactive { get; set; }
}
