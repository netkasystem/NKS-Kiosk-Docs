using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class AdminMessageCustomer
{
    public uint Id { get; set; }

    public string Subject { get; set; } = null!;

    public string Message { get; set; } = null!;

    public DateTime Startdate { get; set; }

    public DateTime Enddate { get; set; }

    public DateTime StartInterrupt { get; set; }

    public DateTime EndInterrupt { get; set; }

    public uint CustomerId { get; set; }

    public uint SiteId { get; set; }

    public uint CreateBy { get; set; }

    public DateTime CreateDate { get; set; }
}

