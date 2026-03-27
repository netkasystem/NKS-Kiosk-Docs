using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ChangePassword
{
    public string Date { get; set; } = null!;

    public string Time { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}

