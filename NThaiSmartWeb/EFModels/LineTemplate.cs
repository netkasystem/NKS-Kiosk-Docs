using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class LineTemplate
{
    public uint LineTemplateId { get; set; }

    public string LineTemplateName { get; set; } = null!;

    public string Message { get; set; } = null!;
}

