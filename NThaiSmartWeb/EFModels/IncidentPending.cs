using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class IncidentPending
{
    public uint Id { get; set; }

    public uint CaseId { get; set; }

    public DateTime PendingStartDate { get; set; }

    public DateTime? PendingStopDate { get; set; }

    public int PendingDuration { get; set; }

    public uint? CaseLogStart { get; set; }

    public uint? CaseLogStop { get; set; }

    public int PendingDurationOnWorkingHour { get; set; }
}
