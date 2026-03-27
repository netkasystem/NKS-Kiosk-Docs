using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CaseLogDeleted
{
    public uint CaseLogId { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public uint CaseId { get; set; }

    public string LoggedBy { get; set; } = null!;

    public uint CaseLogTypeId { get; set; }

    public string CaseLogDescription { get; set; } = null!;

    public uint CaseLogCategoryId { get; set; }

    public string Reference { get; set; } = null!;
}

