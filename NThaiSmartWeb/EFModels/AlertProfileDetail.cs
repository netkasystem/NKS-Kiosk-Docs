using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class AlertProfileDetail
{
    public uint Id { get; set; }

    public uint ProfileId { get; set; }

    public uint StatusId { get; set; }

    public uint EmailTemplateStaffId { get; set; }

    public uint IsSendEmailStaff { get; set; }

    public uint EmailTemplateUserId { get; set; }

    public uint IsSendEmailUser { get; set; }

    public uint SmsTemplateStaffId { get; set; }

    public uint IsSendSmsStaff { get; set; }

    public uint SmsTemplateUserId { get; set; }

    public uint IsSendSmsUser { get; set; }
}

