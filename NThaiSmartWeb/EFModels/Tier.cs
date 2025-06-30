using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Tier
{
    public uint TierId { get; set; }

    public string TierTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte Inactive { get; set; }

    public uint TierSequence { get; set; }
}
