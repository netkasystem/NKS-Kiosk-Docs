using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ContractAttachment
{
    public uint Id { get; set; }

    public uint ContractId { get; set; }

    public string File { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public uint StaffId { get; set; }

    public DateTime CreateDate { get; set; }
}

