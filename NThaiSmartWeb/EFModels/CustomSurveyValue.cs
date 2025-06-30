using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CustomSurveyValue
{
    public uint Id { get; set; }

    public uint Value { get; set; }

    public string Title { get; set; } = null!;

    public uint Percentage { get; set; }
}
