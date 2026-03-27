using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CustomFormFieldValue
{
    public uint CustomFormFieldId { get; set; }

    public string Value { get; set; } = null!;

    public string Lable { get; set; } = null!;

    public uint OrderNum { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string UpdatedBy { get; set; } = null!;
}

