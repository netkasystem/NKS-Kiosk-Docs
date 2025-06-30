using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Contract
{
    public uint ContractId { get; set; }

    public string ContractCode { get; set; } = null!;

    public string ContractTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public uint CustomerId { get; set; }

    public uint SlaId { get; set; }

    public float Availability { get; set; }

    public DateOnly Start { get; set; }

    public DateOnly Expire { get; set; }

    public byte ExpireAlert { get; set; }

    public uint EmailProfileId { get; set; }

    public uint SaleId { get; set; }

    public byte Inactive { get; set; }
}
