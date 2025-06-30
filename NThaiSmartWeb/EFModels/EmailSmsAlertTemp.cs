using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class EmailSmsAlertTemp
{
    public uint Id { get; set; }

    public uint ModuleId { get; set; }

    public uint AlertType { get; set; }

    public string Subject { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string SendTo { get; set; } = null!;

    public uint IsSent { get; set; }

    public DateTime SentDate { get; set; }

    public string Status { get; set; } = null!;

    public string Remark { get; set; } = null!;

    public uint CaseId { get; set; }
}
