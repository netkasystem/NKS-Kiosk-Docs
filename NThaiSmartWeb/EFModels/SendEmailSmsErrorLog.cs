using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SendEmailSmsErrorLog
{
    public uint Id { get; set; }

    public DateTime DateTimestamp { get; set; }

    public string DebugMsg { get; set; } = null!;
}
