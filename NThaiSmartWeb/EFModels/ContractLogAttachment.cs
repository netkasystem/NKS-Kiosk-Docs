using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ContractLogAttachment
{
    public uint Id { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public uint? ContractId { get; set; }

    public string? LoggedBy { get; set; }

    public uint? AttachmentTypeId { get; set; }

    public string? ContractLogDescription { get; set; }
}

