using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class KioskCustomFieldValue
{
    public uint Id { get; set; }

    public uint KioskId { get; set; }

    public string KioskCustomFieldId { get; set; } = null!;

    public string? KioskCustomFieldValue1 { get; set; }
}

