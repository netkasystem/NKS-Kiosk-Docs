using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class MandatoryFieldConfig
{
    public uint Id { get; set; }

    public uint Module { get; set; }

    public string LabelName { get; set; } = null!;

    public string LabelId { get; set; } = null!;

    public string ControlName { get; set; } = null!;

    public string ControlType { get; set; } = null!;

    public ushort IsMandatory { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdatedDate { get; set; }
}

