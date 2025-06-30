using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SurveyManualLog
{
    public uint ContactId { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public string Password { get; set; } = null!;

    public string Key { get; set; } = null!;
}
