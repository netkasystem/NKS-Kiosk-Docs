using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Invoices
{
    public uint Id { get; set; }

    public uint Refdoctype { get; set; }

    public uint Refdocid { get; set; }

    public uint Officeid { get; set; }

    public uint Siteid { get; set; }

    public string? Description { get; set; }

    public DateTime Createdate { get; set; }

    public uint Createby { get; set; }

    public DateTime Updatedate { get; set; }

    public uint Updateby { get; set; }

    public uint Isdelete { get; set; }

    public DateTime? Deletedate { get; set; }

    public uint? Deleteby { get; set; }

    public string Invid { get; set; } = null!;

    public uint Currencyid { get; set; }

    public decimal Taxrate { get; set; }

    public uint Issend { get; set; }
}
