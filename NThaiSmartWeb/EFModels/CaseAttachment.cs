using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CaseAttachment
{
    public uint Id { get; set; }

    public uint CaseId { get; set; }

    public uint CaseLogId { get; set; }

    public uint ModuleId { get; set; }

    public uint AttachmentId { get; set; }
}
