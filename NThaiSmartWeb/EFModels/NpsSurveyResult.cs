using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class NpsSurveyResult
{
    public uint Id { get; set; }

    public uint ModuleId { get; set; }

    public uint CaseId { get; set; }

    public uint Score { get; set; }

    public int NpsScore { get; set; }

    public string Reason { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public string Username { get; set; } = null!;
}
