using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SurveyManualResultDetail
{
    public uint ContactId { get; set; }

    public uint QuestionId { get; set; }

    public string Answer { get; set; } = null!;

    public ushort Flag { get; set; }
}
