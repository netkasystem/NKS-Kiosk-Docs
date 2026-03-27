using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ContractAttachmentOld
{
    public uint Id { get; set; }

    public string Filelink { get; set; } = null!;

    public string Password { get; set; } = null!;
}

