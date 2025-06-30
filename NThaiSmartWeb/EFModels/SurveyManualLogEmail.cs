using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SurveyManualLogEmail
{
    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public uint ContactId { get; set; }

    public string Email { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string Remark { get; set; } = null!;
}
