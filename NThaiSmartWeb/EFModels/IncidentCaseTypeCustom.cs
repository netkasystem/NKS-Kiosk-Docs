using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class IncidentCaseTypeCustom
{
    public uint CaseId { get; set; }

    public uint CaseTypeId { get; set; }

    public string? Customfield1 { get; set; }

    public string? Customfield2 { get; set; }

    public string? Customfield3 { get; set; }
}
