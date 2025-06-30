using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Spare
{
    public uint SpareId { get; set; }

    public string SpareCode { get; set; } = null!;

    public string SpareTitle { get; set; } = null!;

    public string PartNumber { get; set; } = null!;

    public string SerialNumber { get; set; } = null!;

    public uint AssetSubCategoryId { get; set; }

    public uint VendorId { get; set; }

    public uint OfficeId { get; set; }

    public uint ItemStatusId { get; set; }

    public DateOnly Start { get; set; }

    public DateOnly Expire { get; set; }

    public byte ExpireAlert { get; set; }

    public string Description { get; set; } = null!;
}
