using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class StaffLocationTracking
{
    public uint Id { get; set; }

    public uint StaffId { get; set; }

    public uint CaseId { get; set; }

    public uint ModuleId { get; set; }

    public decimal Lat { get; set; }

    public decimal Lng { get; set; }

    public DateTime UpdatedDate { get; set; }
}
