using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class IncidentChange
{
    public uint Id { get; set; }

    public uint IncidentId { get; set; }

    public uint ChangeId { get; set; }

    public uint Linked { get; set; }
}

