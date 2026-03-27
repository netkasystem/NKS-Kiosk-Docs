using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class BusinessHoursProfile
{
    public uint Id { get; set; }

    public string BusinessHoursTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public ushort Inactive { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public virtual ICollection<BusinessHour> BusinessHour { get; set; } = new List<BusinessHour>();

    public virtual ICollection<Holiday> Holiday { get; set; } = new List<Holiday>();
}

