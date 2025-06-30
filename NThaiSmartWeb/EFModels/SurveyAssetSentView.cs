using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SurveyAssetSentView
{
    public int AssetId { get; set; }

    public int AssetCode { get; set; }

    public int RecipientName { get; set; }

    public int RecipientEmail { get; set; }
}
