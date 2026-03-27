using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ContactChannel
{
    public uint ContactChannelId { get; set; }

    public string ContactChannelTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte Inactive { get; set; }

    public uint ContactChannelSequence { get; set; }
}

