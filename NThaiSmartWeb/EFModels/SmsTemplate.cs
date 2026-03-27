using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SmsTemplate
{
    public uint SmsTemplateId { get; set; }

    public string SmsTemplateName { get; set; } = null!;

    public string Message { get; set; } = null!;

    public uint TemplateTypeId { get; set; }
}

