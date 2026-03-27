using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Incident
{
    public uint Id { get; set; }

    public string CaseId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string CaseDescription { get; set; } = null!;

    public uint CaseSubCategoryId { get; set; }

    public uint CaseCategoryId { get; set; }

    public uint PriorityId { get; set; }

    public uint TierId { get; set; }

    public uint SiteId { get; set; }

    public uint ContractId { get; set; }

    public uint OperatorId { get; set; }

    public uint EngineerId { get; set; }

    public uint ContactId { get; set; }

    public uint ContactChannelId { get; set; }

    public uint CaseStatusId { get; set; }

    public bool ResponseOverdue { get; set; }

    public bool OnsiteOverdue { get; set; }

    public bool ResolveOverdue { get; set; }

    public uint ResponseDuration { get; set; }

    public uint OnsiteDuration { get; set; }

    public uint ResolveDuration { get; set; }

    public uint CaseDuration { get; set; }

    public uint ClosureTypeId { get; set; }

    public bool EnableAuditLog { get; set; }

    public bool EnableWorkLog { get; set; }

    public string CustomerCaseId { get; set; } = null!;

    public string VendorCaseId { get; set; } = null!;

    public string Reference { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string CaseIdFormat { get; set; } = null!;

    public uint ParentCaseId { get; set; }

    public uint ResolutionTypeId { get; set; }

    public string? ResolutionDetail { get; set; }

    public string Remark { get; set; } = null!;

    public uint StaffId { get; set; }

    public DateTime Downtime { get; set; }

    public DateTime Uptime { get; set; }

    public byte IsKnowledge { get; set; }

    public uint ServiceTypeId { get; set; }

    public uint CaseTypeId { get; set; }

    public uint IsSlaEffect { get; set; }

    public uint TeamId { get; set; }

    public string CaseImportReference { get; set; } = null!;

    public uint SymptomTypeId { get; set; }

    public DateTime PendingStartDate { get; set; }

    public DateTime PendingStopDate { get; set; }

    public DateTime ResolvedDate { get; set; }

    public DateTime ClosedDate { get; set; }

    public uint RfcId { get; set; }

    public uint ProblemId { get; set; }

    public uint LocationId { get; set; }

    public uint SdId { get; set; }

    public string ContactDetail { get; set; } = null!;

    public byte Approve { get; set; }

    public uint ApproveBy { get; set; }

    public string? Customfield1 { get; set; }

    public string? Customfield2 { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime RequestedDate { get; set; }

    public string Tags { get; set; } = null!;

    public uint OlaId { get; set; }

    public uint NumReassign { get; set; }

    public uint RiskId { get; set; }

    public uint ReportTypeId { get; set; }

    public uint OfficeId { get; set; }

    public byte IsMandatory { get; set; }

    public byte IsSevere { get; set; }

    public string ReportDetails { get; set; } = null!;

    public string? Signature { get; set; }

    public string? LocationCustomText { get; set; }
}

