using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Template
{
    public uint TemplateId { get; set; }

    public string TemplateTitle { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string ImgFooter { get; set; } = null!;

    public uint AlertTypeId { get; set; }

    public uint ModuleId { get; set; }
}
