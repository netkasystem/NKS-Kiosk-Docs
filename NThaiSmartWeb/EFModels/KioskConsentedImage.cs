using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class KioskConsentedImage
{
    public uint Id { get; set; }

    public uint KioskConsentedId { get; set; }

    public string FaceIdcard { get; set; } = null!;

    public string FaceCapture { get; set; } = null!;
}
