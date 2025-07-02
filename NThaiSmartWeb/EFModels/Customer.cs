using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Customer
{
    public uint CustomerId { get; set; }

    public string CustomerCode { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string CustomerNameEn { get; set; } = null!;

    public uint CustomerTypeId { get; set; }

    public uint SectorId { get; set; }

    public byte Inactive { get; set; }

    public virtual ICollection<Contact> Contact { get; set; } = new List<Contact>();

    public virtual ICollection<Region> Region { get; set; } = new List<Region>();
}
