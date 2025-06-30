using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SurveySentForm
{
    public uint Id { get; set; }

    public string SurveySendName { get; set; } = null!;

    public uint SurveyFormId { get; set; }

    public uint ModuleId { get; set; }

    public uint CaseTypeId { get; set; }

    public uint AssetTypeId { get; set; }

    public uint StaffId { get; set; }

    /// <summary>
    /// 0 = Draft, 1 = opening, 2 = close
    /// </summary>
    public uint Status { get; set; }

    public string EmailSubject { get; set; } = null!;

    public string EmailMessage { get; set; } = null!;
}
