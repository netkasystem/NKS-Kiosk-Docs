using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class AlertType
{
    public uint AlertTypeId { get; set; }

    public string AlertTypeTitle { get; set; } = null!;
}
