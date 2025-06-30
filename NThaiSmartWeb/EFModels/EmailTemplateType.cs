using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class EmailTemplateType
{
    public uint Id { get; set; }

    public string TemplateType { get; set; } = null!;

    public virtual ICollection<EmailTemplate> EmailTemplate { get; set; } = new List<EmailTemplate>();
}
