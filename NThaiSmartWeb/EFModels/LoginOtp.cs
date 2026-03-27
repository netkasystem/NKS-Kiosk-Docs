using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class LoginOtp
{
    public uint Id { get; set; }

    public string Username { get; set; } = null!;

    public string Otp { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}

