using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class PropertyFieldValueMaster
{
    public uint Id { get; set; }

    public uint PropertyFieldId { get; set; }

    public string Text { get; set; } = null!;

    public string Value { get; set; } = null!;

    public uint OrderNum { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdatedDate { get; set; }
}

