using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class BusinessHour
{
    public uint Id { get; set; }

    public string Day { get; set; } = null!;

    public ulong WorkDay { get; set; }

    public string Open { get; set; } = null!;

    public string Close { get; set; } = null!;

    public uint ProfileId { get; set; }

    public virtual ICollection<Holiday> Holiday { get; set; } = new List<Holiday>();

    public virtual BusinessHoursProfile Profile { get; set; } = null!;
}
