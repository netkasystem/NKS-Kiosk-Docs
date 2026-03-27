using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Currency
{
    public uint Id { get; set; }

    public string CurrencyTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Taxrate { get; set; }

    public uint Sequence { get; set; }
}

