using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SurveySentFormDetail
{
    public uint Id { get; set; }

    public uint SurveySentFormId { get; set; }

    /// <summary>
    /// Asset = asset_id
    /// </summary>
    public uint KeyReferId { get; set; }

    public string RecipientName { get; set; } = null!;

    public string RecipientEmail { get; set; } = null!;

    public string SurveyAnswerData { get; set; } = null!;

    /// <summary>
    /// 0 = Draft, 1 = Requested, 2 = Responded
    /// </summary>
    public byte Status { get; set; }
}
