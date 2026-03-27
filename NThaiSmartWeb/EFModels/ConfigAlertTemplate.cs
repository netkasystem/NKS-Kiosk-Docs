using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ConfigAlertTemplate
{
    public uint Id { get; set; }

    public string Description { get; set; } = null!;

    public uint ModuleId { get; set; }

    public uint CaseLogTypeId { get; set; }

    public uint CaseStatusId { get; set; }

    public uint AlertTypeId { get; set; }

    public uint TemplateUserId { get; set; }

    public uint TemplateStaffId { get; set; }

    public bool IsSendUser { get; set; }

    public bool IsSendStaff { get; set; }
}

