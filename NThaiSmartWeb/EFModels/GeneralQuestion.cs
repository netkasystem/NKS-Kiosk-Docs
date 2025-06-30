using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class GeneralQuestion
{
    public uint QuestionId { get; set; }

    public string Question { get; set; } = null!;

    public uint OrderNum { get; set; }
}
