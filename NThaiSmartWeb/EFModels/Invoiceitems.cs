using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Invoiceitems
{
    public uint Id { get; set; }

    public uint Invoiceid { get; set; }

    public uint Itemseq { get; set; }

    public string Itemname { get; set; } = null!;

    public uint Itemhour { get; set; }

    public uint Itemmin { get; set; }

    public decimal Itemprice { get; set; }

    public decimal Itemtax { get; set; }

    public decimal Itemtotal { get; set; }

    /// <summary>
    /// 0=none,1=include,2=not include
    /// </summary>
    public uint Itemtaxtype { get; set; }
}

