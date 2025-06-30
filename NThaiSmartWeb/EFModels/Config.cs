using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Config
{
    public uint Id { get; set; }

    public string WindowsUsername { get; set; } = null!;

    public string WindowsPassword { get; set; } = null!;

    public string DomainName { get; set; } = null!;

    public string WindowsServerName { get; set; } = null!;

    public string ServerIp { get; set; } = null!;

    public string SmtpServer { get; set; } = null!;

    public string SmtpSender { get; set; } = null!;

    public string SmtpPassword { get; set; } = null!;

    public string SmtpAuth { get; set; } = null!;

    public string SmsUrl { get; set; } = null!;

    public string SmsUserKeyword { get; set; } = null!;

    public string SmsPasswordKeyword { get; set; } = null!;

    public string SmsNumberKeyword { get; set; } = null!;

    public string SmsMessageKeyword { get; set; } = null!;

    public string SmsUsername { get; set; } = null!;

    public string SmsPassword { get; set; } = null!;

    public string SmsProtocol { get; set; } = null!;

    public string SmsResult { get; set; } = null!;

    public string Product { get; set; } = null!;

    public string ProductKey { get; set; } = null!;

    public byte Satisfaction { get; set; }
}
