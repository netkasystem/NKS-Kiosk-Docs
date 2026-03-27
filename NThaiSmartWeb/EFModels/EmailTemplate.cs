using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class EmailTemplate
{
    public uint Id { get; set; }

    public string TemplateName { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string ImgFooter { get; set; } = null!;

    public uint TemplateTypeId { get; set; }

    public virtual EmailTemplateType TemplateType { get; set; } = null!;
}

