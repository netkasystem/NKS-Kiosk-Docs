using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class NsdxFileAttatchment
{
    public uint AttatchmentId { get; set; }

    public string AttatchmentFileName { get; set; } = null!;

    public string AttatchmentFileType { get; set; } = null!;

    public string AttatchmentFileBase64 { get; set; } = null!;

    public uint AttatchmentFileCreateBy { get; set; }

    public DateTime AttatchmentFileCreateDate { get; set; }
}

