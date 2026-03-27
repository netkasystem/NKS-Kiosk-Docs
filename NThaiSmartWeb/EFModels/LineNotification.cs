using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class LineNotification
{
    public uint Id { get; set; }

    public uint ModuleId { get; set; }

    public string JobId { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public DateTime AlertDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public ushort IsProcess { get; set; }
}

