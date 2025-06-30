using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class WebboardReply
{
    public uint ReplyId { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public uint TopicId { get; set; }

    public string Username { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string EditBy { get; set; } = null!;

    public DateTime EditDate { get; set; }

    public TimeOnly EditTime { get; set; }
}
