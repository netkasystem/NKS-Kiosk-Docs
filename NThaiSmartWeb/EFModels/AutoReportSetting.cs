using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class AutoReportSetting
{
    public uint Id { get; set; }

    public string Report { get; set; } = null!;

    public string ReportType { get; set; } = null!;

    public string Value { get; set; } = null!;

    public string Username { get; set; } = null!;
}

