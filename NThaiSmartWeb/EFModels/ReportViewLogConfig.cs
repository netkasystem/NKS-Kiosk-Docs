using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ReportViewLogConfig
{
    public uint Id { get; set; }

    public string Path { get; set; } = null!;

    public string Table { get; set; } = null!;

    public bool Add { get; set; }

    public bool Edit { get; set; }

    public bool Delete { get; set; }

    public bool Export { get; set; }
}

