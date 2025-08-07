using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class KioskCustomField
{
    public uint Id { get; set; }

    public uint ContractId { get; set; }

    public string FormFieldJson { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }
}
