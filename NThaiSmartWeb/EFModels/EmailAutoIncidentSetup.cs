using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class EmailAutoIncidentSetup
{
    public uint Id { get; set; }

    public string MailServer { get; set; } = null!;

    public string Port { get; set; } = null!;

    public string Secure { get; set; } = null!;

    public string OpenKeyword { get; set; } = null!;

    public string User { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string ServiceTypeTitle { get; set; } = null!;
}

