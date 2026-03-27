using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CustomerType
{
    public uint CustomerTypeId { get; set; }

    public string CustomerTypeTitle { get; set; } = null!;

    public string Description { get; set; } = null!;
}

