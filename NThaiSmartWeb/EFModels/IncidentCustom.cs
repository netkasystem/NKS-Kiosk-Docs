using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class IncidentCustom
{
    public uint Id { get; set; }

    public string FieldName { get; set; } = null!;

    public string LabelName { get; set; } = null!;
}

