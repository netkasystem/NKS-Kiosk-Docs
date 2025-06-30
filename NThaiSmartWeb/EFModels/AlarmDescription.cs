using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class AlarmDescription
{
    public int Id { get; set; }

    public string? Alarm { get; set; }

    public string? Description { get; set; }
}
