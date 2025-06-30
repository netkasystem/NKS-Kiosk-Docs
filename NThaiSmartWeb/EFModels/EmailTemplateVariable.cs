using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class EmailTemplateVariable
{
    public uint Id { get; set; }

    public uint ServiceTypeId { get; set; }

    public string FieldName { get; set; } = null!;

    public string VariableName { get; set; } = null!;

    public uint TemplateType { get; set; }

    public string Description { get; set; } = null!;

    public string MappingControlName { get; set; } = null!;
}
