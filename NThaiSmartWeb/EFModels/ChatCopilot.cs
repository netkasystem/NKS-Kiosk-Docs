using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ChatCopilot
{
    public uint Id { get; set; }

    public string Question { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public DateTime UpdatedDate { get; set; }

    public uint UpdatedBy { get; set; }
}

