using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ContractCustomField
{
    public uint Id { get; set; }

    public string ContractCustomFieldId { get; set; } = null!;

    public string? ContractCustomFieldValue { get; set; }

    public uint ContractId { get; set; }
}

