using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class MSccmDataSource
{
    public uint SccmId { get; set; }

    public string SccmName { get; set; } = null!;

    public string SccmIpAddress { get; set; } = null!;

    public ushort SccmPort { get; set; }

    public string SccmUsername { get; set; } = null!;

    public string SccmPassword { get; set; } = null!;

    public string SccmDatabaseName { get; set; } = null!;

    public ulong SccmInactive { get; set; }
}
