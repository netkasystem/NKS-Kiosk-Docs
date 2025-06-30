using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SurveyForm
{
    public uint Id { get; set; }

    public uint ModuleId { get; set; }

    public uint CaseTypeId { get; set; }

    public string SurveyName { get; set; } = null!;

    public string SurveyFormData { get; set; } = null!;

    public byte Inactive { get; set; }
}
