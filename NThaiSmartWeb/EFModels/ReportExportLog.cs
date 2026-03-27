using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ReportExportLog
{
    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public string Username { get; set; } = null!;

    public string Report { get; set; } = null!;

    public string Detail { get; set; } = null!;
}

