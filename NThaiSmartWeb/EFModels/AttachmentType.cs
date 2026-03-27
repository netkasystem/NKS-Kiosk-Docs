using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class AttachmentType
{
    public uint AttachmentTypeId { get; set; }

    public string AttachmentTypeTitle { get; set; } = null!;

    public string? Description { get; set; }
}

