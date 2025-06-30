using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class DatasourceConfig
{
    public uint Id { get; set; }

    public string IpAddress { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Port { get; set; } = null!;
}
