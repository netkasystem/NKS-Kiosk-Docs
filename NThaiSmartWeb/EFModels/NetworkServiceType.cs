using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class NetworkServiceType
{
    public uint NwsrvTypeId { get; set; }

    public string NwsrvTypeTitle { get; set; } = null!;

    public string NwsrvTypeDescription { get; set; } = null!;

    public uint Inactive { get; set; }
}

