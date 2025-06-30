using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class UsoPersonList
{
    public uint Id { get; set; }

    public double? PId { get; set; }

    public string? Prefix { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public double? HCode { get; set; }

    public string? No { get; set; }

    public string? Moo { get; set; }

    public string? SubDistrict { get; set; }

    public string? District { get; set; }

    public string? Province { get; set; }

    public string? ZipCode { get; set; }

    public string? Mobile { get; set; }

    public string? Network { get; set; }
}
