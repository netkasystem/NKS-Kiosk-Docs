using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class KioskMonitoringPin
{
    public uint Id { get; set; }

    public uint StaffId { get; set; }

    public uint KioskId { get; set; }
}

