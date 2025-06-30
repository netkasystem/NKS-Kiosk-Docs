using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class RootCause
{
    public uint RootCauseId { get; set; }

    public string RootCauseTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public uint Inactive { get; set; }

    public uint ServiceTypeId { get; set; }
}
