using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Login
{
    public long Id { get; set; }

    public DateOnly? DateIn { get; set; }

    public TimeOnly? TimeIn { get; set; }

    public DateOnly? DateOut { get; set; }

    public TimeOnly? TimeOut { get; set; }

    public string? Username { get; set; }

    public string? Ip { get; set; }

    public string? SessionId { get; set; }
}

