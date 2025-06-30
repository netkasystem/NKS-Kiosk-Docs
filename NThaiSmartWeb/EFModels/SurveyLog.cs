using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SurveyLog
{
    public string CaseLogId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Key { get; set; } = null!;
}
