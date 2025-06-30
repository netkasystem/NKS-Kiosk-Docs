using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class WorkflowRuleCondition
{
    public uint Id { get; set; }

    public uint WorkflowRuleId { get; set; }

    public string ColumnName { get; set; } = null!;

    public string ColumnOperator { get; set; } = null!;

    public string ColumnValue { get; set; } = null!;

    public bool Inactive { get; set; }

    public DateTime CreatedDate { get; set; }
}
