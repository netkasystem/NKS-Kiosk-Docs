using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class IncidentCustomField
{
    public uint Id { get; set; }

    public string IncidentCustomFieldId { get; set; } = null!;

    public string? IncidentCustomFieldValue { get; set; }

    public uint IncidentId { get; set; }
}

