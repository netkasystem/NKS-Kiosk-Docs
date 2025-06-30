using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CauseBy
{
    public uint CauseById { get; set; }

    public string CauseByTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public ushort SlaAffected { get; set; }

    public ushort Inactive { get; set; }
}
