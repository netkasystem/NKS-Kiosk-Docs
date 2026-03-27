using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class AlertProfile
{
    public uint AlertProfileId { get; set; }

    public string ProfileName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public uint ModuleId { get; set; }
}

