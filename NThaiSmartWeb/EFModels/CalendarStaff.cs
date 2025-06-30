using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CalendarStaff
{
    public uint Id { get; set; }

    public uint CalendarId { get; set; }

    public uint StaffId { get; set; }
}
