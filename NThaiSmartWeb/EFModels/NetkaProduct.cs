using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class NetkaProduct
{
    public string Product { get; set; } = null!;

    public string PartNumber { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte Order { get; set; }

    public int LicenseNode { get; set; }

    public int LicenseInterface { get; set; }

    public string UsedNodeSql { get; set; } = null!;

    public string UsedInterfaceSql { get; set; } = null!;
}
