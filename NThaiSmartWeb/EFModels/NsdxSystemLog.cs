using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class NsdxSystemLog
{
    public uint Adminsystemlogid { get; set; }

    public DateTime? Adminsystemlogdatetime { get; set; }

    public string Adminsystemlogusername { get; set; } = null!;

    public string Adminsystemlogpage { get; set; } = null!;

    public string Adminsystemlogtablename { get; set; } = null!;

    public string Adminsystemlogaction { get; set; } = null!;

    public string Adminsystemlogdescription { get; set; } = null!;

    public string Adminsystemlogoldvalue { get; set; } = null!;

    public string Adminsystemlognewvalue { get; set; } = null!;
}
