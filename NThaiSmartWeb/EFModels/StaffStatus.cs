using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class StaffStatus
{
    public uint StaffStatusId { get; set; }

    public string StaffStatusTitle { get; set; } = null!;
}

