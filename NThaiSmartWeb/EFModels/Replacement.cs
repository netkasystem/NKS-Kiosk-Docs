using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Replacement
{
    public uint ReplacementId { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public uint CaseId { get; set; }

    public uint AssetId { get; set; }

    public uint SpareId { get; set; }

    public string Comment { get; set; } = null!;
}
