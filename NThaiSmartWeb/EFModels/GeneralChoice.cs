using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class GeneralChoice
{
    public uint QuestionId { get; set; }

    public ushort QuestionChoice { get; set; }

    public string Answer { get; set; } = null!;
}

