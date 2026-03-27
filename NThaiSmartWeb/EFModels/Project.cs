using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Project
{
    public uint Id { get; set; }

    public string ProjectName { get; set; } = null!;

    public string Description { get; set; } = null!;
}

