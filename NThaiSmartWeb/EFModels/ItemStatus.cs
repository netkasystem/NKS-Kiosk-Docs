using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ItemStatus
{
    public uint ItemStatusId { get; set; }

    public string ItemStatusTitle { get; set; } = null!;

    public byte Inactive { get; set; }

    public byte Isdispose { get; set; }

    public byte Isplanning { get; set; }
}
