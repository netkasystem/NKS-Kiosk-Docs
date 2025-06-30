using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SurveyResultDetail
{
    public string CaseId { get; set; } = null!;

    public uint QuestionId { get; set; }

    public string Answer { get; set; } = null!;

    public ushort Flag { get; set; }
}
