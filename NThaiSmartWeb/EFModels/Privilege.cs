using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Privilege
{
    public uint Id { get; set; }

    public uint Level { get; set; }

    public uint MenuId { get; set; }
}

