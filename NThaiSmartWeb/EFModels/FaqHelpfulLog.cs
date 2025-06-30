using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class FaqHelpfulLog
{
    public uint Id { get; set; }

    public uint FaqId { get; set; }

    public string Username { get; set; } = null!;

    public bool Like { get; set; }

    public bool Dislike { get; set; }

    public DateTime CreatedDate { get; set; }
}
