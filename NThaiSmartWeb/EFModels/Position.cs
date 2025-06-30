using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Position
{
    public uint PositionId { get; set; }

    public string PositionTitle { get; set; } = null!;

    public byte IsVip { get; set; }
}
