using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CustomSurveyResult
{
    public uint Id { get; set; }

    public uint ModuleId { get; set; }

    public uint CaseId { get; set; }

    public uint Result { get; set; }

    public string Remark { get; set; } = null!;

    public DateTime Timestamp { get; set; }
}
