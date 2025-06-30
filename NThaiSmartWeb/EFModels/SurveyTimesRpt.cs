using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SurveyTimesRpt
{
    public int ModuleName { get; set; }

    public int SurveySendName { get; set; }

    public int SurveyName { get; set; }

    public int RecipientName { get; set; }

    public int RecipientEmail { get; set; }

    public int AssetCode { get; set; }

    public int SurveyStatus { get; set; }

    public int Sender { get; set; }

    public int Lastupdate { get; set; }
}
