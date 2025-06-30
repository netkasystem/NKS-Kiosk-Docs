using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class RiskQuestion
{
    public uint Id { get; set; }

    public uint ServiceCatalogId { get; set; }

    public string Question { get; set; } = null!;

    public string A { get; set; } = null!;

    public string B { get; set; } = null!;

    public string C { get; set; } = null!;

    public string D { get; set; } = null!;

    public uint Sequence { get; set; }

    public string QuestionJson { get; set; } = null!;
}
