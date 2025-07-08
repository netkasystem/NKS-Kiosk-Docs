using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CustomForm
{
    public uint Id { get; set; }

    public string ProfileName { get; set; } = null!;

    public string FormFieldJson { get; set; } = null!; 

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdatedDate { get; set; } 
}
