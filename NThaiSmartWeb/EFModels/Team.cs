using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Team
{
    public uint TeamId { get; set; }

    public string TeamTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string LineToken { get; set; } = null!;
}
