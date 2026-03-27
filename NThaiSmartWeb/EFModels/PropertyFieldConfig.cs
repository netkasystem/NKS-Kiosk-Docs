using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class PropertyFieldConfig
{
    public uint Id { get; set; }

    public uint ModuleId { get; set; }

    public uint ControlType { get; set; }

    public string DisplayTitle { get; set; } = null!;

    public ushort IsRequired { get; set; }

    public string FieldName { get; set; } = null!;

    public uint MaxLength { get; set; }

    public ushort IsReadOnly { get; set; }

    public string DependFields { get; set; } = null!;

    public string DefaultValue { get; set; } = null!;

    public string Data { get; set; } = null!;

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdatedDate { get; set; }

    public ushort Inactive { get; set; }

    public string HintDisplay { get; set; } = null!;

    public ushort AllowDelete { get; set; }
}

