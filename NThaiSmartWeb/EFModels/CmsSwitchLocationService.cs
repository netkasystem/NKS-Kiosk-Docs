using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CmsSwitchLocationService
{
    public string Facility { get; set; } = null!;

    public string Room { get; set; } = null!;

    public string Rack { get; set; } = null!;

    public string Node { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Ip { get; set; } = null!;

    public string Portid { get; set; } = null!;

    public string Port { get; set; } = null!;

    public string Service { get; set; } = null!;
}
