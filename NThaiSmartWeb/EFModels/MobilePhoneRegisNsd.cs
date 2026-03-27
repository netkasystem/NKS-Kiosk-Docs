using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class MobilePhoneRegisNsd
{
    public uint Id { get; set; }

    public string Username { get; set; } = null!;

    public string MacAddress { get; set; } = null!;

    public string RegisDate { get; set; } = null!;

    public string RegisTime { get; set; } = null!;

    public byte Inactive { get; set; }
}

