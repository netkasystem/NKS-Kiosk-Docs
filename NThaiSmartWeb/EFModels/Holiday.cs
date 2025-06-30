using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Holiday
{
    public uint HolidayId { get; set; }

    public DateOnly HolidayStartdate { get; set; }

    public DateOnly HolidayEnddate { get; set; }

    public string HolidayDescription { get; set; } = null!;

    public ulong Fixed { get; set; }

    public uint ProfileId { get; set; }

    public virtual BusinessHour Profile { get; set; } = null!;
}
