using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class KioskConsented
{
    public uint Id { get; set; }

    public uint KioskAreaId { get; set; }

    public string Idcard { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime ConsentedDate { get; set; }

    public uint ConsentedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public uint UpdatedBy { get; set; }
}
