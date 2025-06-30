using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Tutorial
{
    public uint Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }
}
