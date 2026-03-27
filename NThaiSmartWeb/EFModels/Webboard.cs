using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Webboard
{
    public uint TopicId { get; set; }

    public string Subject { get; set; } = null!;

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public string Author { get; set; } = null!;

    public uint ReadNum { get; set; }

    public uint Posts { get; set; }

    public uint CategoryId { get; set; }

    public byte Pin { get; set; }

    public byte Locks { get; set; }
}

