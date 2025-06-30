using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class StaffLocationLog
{
    public uint Id { get; set; }

    public uint CaseLogId { get; set; }

    public uint StaffId { get; set; }

    public decimal Lat { get; set; }

    public decimal Lng { get; set; }

    public string Remark { get; set; } = null!;

    public DateTime UpdatedDate { get; set; }
}
