using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ReportViewLog
{
    public uint Id { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public string Username { get; set; } = null!;

    public string Report { get; set; } = null!;

    public string Detail { get; set; } = null!;

    public string Action { get; set; } = null!;

    public uint ReportViewLogConfigId { get; set; }

    public uint MenuId { get; set; }
}
