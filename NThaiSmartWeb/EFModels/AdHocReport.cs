using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class AdHocReport
{
    public uint Id { get; set; }

    public string RptName { get; set; } = null!;

    public string RptDescription { get; set; } = null!;

    public uint RptType { get; set; }

    public string CretedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public ushort Inactive { get; set; }

    public uint IsPublic { get; set; }

    public uint IsChart { get; set; }

    public uint IsGrid { get; set; }

    public string TimeField { get; set; } = null!;

    public string TimeVal { get; set; } = null!;

    public uint ModuleId { get; set; }

    public uint CanDelete { get; set; }

    public bool IsCustomer { get; set; }

    public byte IsShareTeam { get; set; }

    public string ReportShareTeamId { get; set; } = null!;
}

