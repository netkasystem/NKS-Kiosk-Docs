using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class FileValidation
{
    public uint Id { get; set; }

    public string FileExtension { get; set; } = null!;

    public string DecSignature { get; set; } = null!;

    public string HexSignature { get; set; } = null!;

    public byte Validate { get; set; }

    public string Description { get; set; } = null!;
}

