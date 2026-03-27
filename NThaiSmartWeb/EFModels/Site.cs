using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Site
{
    public uint SiteId { get; set; }

    public string SiteTitle { get; set; } = null!;

    public string SiteTitleEn { get; set; } = null!;

    public string Building { get; set; } = null!;

    public string Level { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Street { get; set; } = null!;

    public int? Tambol { get; set; }

    public int? Amphur { get; set; }

    public int? Province { get; set; }

    public uint? Country { get; set; }

    public decimal Lat { get; set; }

    public decimal Lng { get; set; }

    public string Zip { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public string Web { get; set; } = null!;

    public string Hq { get; set; } = null!;

    public uint CustomerId { get; set; }

    public uint RegionId { get; set; }

    public byte Inactive { get; set; }

    public virtual ICollection<Contact> Contact { get; set; } = new List<Contact>();
}

