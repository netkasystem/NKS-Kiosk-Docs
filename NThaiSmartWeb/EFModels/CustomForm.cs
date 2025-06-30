using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CustomForm
{
    public uint Id { get; set; }

    public uint FunctionId { get; set; }

    public uint ServiceCatalogId { get; set; }

    public string FormFieldJson { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdatedDate { get; set; }

    public virtual NsdFunction Function { get; set; } = null!;

    public virtual CaseType ServiceCatalog { get; set; } = null!;
}
