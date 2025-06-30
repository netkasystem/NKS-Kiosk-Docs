using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class EmailProfileDetail
{
    public uint ProfileDetailId { get; set; }

    public uint ProfileId { get; set; }

    public uint StatusId { get; set; }

    public uint EmailTemplateId { get; set; }

    public uint IsSendEmail { get; set; }

    public uint SmsTemplateId { get; set; }

    public uint IsSendSms { get; set; }
}
