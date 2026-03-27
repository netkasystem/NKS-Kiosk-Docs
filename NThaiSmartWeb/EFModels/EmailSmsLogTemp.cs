using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class EmailSmsLogTemp
{
    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public uint CaseId { get; set; }

    public uint CaseLogId { get; set; }

    public string Mobile { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string Remark { get; set; } = null!;
}

