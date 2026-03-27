using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CustomFormField
{
    public uint CustomFormId { get; set; }

    public uint FuctionId { get; set; }

    public uint ServiceTypeId { get; set; }

    public string FieldDisplay { get; set; } = null!;

    public string FieldName { get; set; } = null!;

    public string PlaceHolder { get; set; } = null!;

    public string Hint { get; set; } = null!;

    public uint FieldTypeId { get; set; }

    public ushort IsRequired { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdatedDate { get; set; }

    public uint OrderNum { get; set; }
}

