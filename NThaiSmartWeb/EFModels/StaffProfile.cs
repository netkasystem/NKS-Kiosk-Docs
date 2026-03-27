using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class StaffProfile
{
    public uint Id { get; set; }

    public uint StaffId { get; set; }

    public ushort TaskAssignNoti { get; set; }

    public ushort TaskEscalationNoti { get; set; }

    public ushort CalendarNoti { get; set; }

    public ushort PrivateMsgNoti { get; set; }

    public int? MenuId { get; set; }
}

