using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class LoginFail
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Ip { get; set; }

    public byte? Lock { get; set; }

    public DateTime Datetime { get; set; }
}

