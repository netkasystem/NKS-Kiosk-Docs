using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class NsdxDashboardProfile
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string JsonTemplate { get; set; } = null!;

    public string JsonData { get; set; } = null!;

    public ulong IsActive { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public uint? StaffId { get; set; }
}

