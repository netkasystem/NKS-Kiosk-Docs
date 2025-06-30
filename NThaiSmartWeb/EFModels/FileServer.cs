using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class FileServer
{
    public uint FsId { get; set; }

    public string Filelink { get; set; } = null!;

    public string Password { get; set; } = null!;
}
