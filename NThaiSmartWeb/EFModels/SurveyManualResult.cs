using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SurveyManualResult
{
    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public uint ContactId { get; set; }

    public float ScoreEarned { get; set; }

    public ushort ScoreTotal { get; set; }

    public string ScoreGrade { get; set; } = null!;

    public string Suggestion { get; set; } = null!;
}
