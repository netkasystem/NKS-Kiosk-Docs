using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class NotificationTask
{
    public uint Id { get; set; }

    public DateTime? AlertDate { get; set; }

    public string Subject { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string Message { get; set; } = null!;

    public uint SendById { get; set; }

    public uint RecipientId { get; set; }

    public ushort IsRead { get; set; }

    public ushort IsDeleted { get; set; }

    public uint MessageType { get; set; }
}

