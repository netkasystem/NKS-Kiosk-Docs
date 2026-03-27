using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class KioskContractAttachment
{
    public uint Id { get; set; }

    public uint KioskContractId { get; set; }

    public string File { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public uint StaffId { get; set; }

    public DateTime CreateDate { get; set; }
}

