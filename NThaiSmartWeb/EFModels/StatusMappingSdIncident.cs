using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class StatusMappingSdIncident
{
    public uint Id { get; set; }

    public uint SdStatusId { get; set; }

    public uint IncidentStatusId { get; set; }
}

