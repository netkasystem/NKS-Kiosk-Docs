using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SatisfactionSurveyRpt
{
    public int Id { get; set; }

    public int ModuleId { get; set; }

    public int ModuleName { get; set; }

    public int CaseId { get; set; }

    public int Result { get; set; }

    public int Remark { get; set; }

    public int Score { get; set; }

    public int ScoreTitle { get; set; }

    public int Percentage { get; set; }

    public int RequestedDate { get; set; }
}
