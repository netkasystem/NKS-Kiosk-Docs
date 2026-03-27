using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class AlarmType
{
    public uint AlarmTypeId { get; set; }

    public string AlarmTypeTitle { get; set; } = null!;

    public string AlarmTypeDescription { get; set; } = null!;

    public string Remark { get; set; } = null!;

    public uint Inactive { get; set; }
}

