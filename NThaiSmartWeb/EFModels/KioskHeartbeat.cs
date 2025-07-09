using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class KioskHeartbeat
{
    public uint Id { get; set; }

    public uint KioskId { get; set; }

    public DateTime Lastupdate { get; set; }
}
