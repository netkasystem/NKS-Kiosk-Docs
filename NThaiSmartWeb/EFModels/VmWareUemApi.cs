using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class VmWareUemApi
{
    public uint Id { get; set; }

    public string PathName { get; set; } = null!;

    public string PathUrl { get; set; } = null!;

    public string ApiType { get; set; } = null!;
}
