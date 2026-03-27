using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class IncidentEscalationLog
{
    public int Id { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? Time { get; set; }

    public int IncidentId { get; set; }

    public string? Reason { get; set; }

    public string? Description { get; set; }

    public int? OldTierId { get; set; }

    public int? NewTierId { get; set; }

    public int? EngineerId { get; set; }
}

