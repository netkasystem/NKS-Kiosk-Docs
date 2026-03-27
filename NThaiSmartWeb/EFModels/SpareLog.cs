using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SpareLog
{
    public uint SpareLogId { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public uint SpareId { get; set; }

    public string LoggedBy { get; set; } = null!;

    public uint ItemStatusId { get; set; }

    public string Description { get; set; } = null!;
}

