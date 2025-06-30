using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class WorkflowRule
{
    public uint Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public uint ModuleId { get; set; }

    public uint CaseLogTypeId { get; set; }

    public uint CaseStatusId { get; set; }

    public string WorkflowId { get; set; } = null!;

    public bool Inactive { get; set; }
}
