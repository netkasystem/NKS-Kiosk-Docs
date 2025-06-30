using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class VmWareUemAssetInfo
{
    public uint Id { get; set; }

    public uint AssetId { get; set; }

    public string Info { get; set; } = null!;

    public string? DeviceId { get; set; }

    public string? MacAddress { get; set; }

    public string? Udid { get; set; }

    public string? SerialNumber { get; set; }

    public string? Imei { get; set; }

    public DateTime UpdatedDate { get; set; }
}
