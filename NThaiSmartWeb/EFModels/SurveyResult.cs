using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SurveyResult
{
    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public string CaseId { get; set; } = null!;

    public float ScoreEarned { get; set; }

    public ushort ScoreTotal { get; set; }

    public string ScoreGrade { get; set; } = null!;

    public string Suggestion { get; set; } = null!;
}
