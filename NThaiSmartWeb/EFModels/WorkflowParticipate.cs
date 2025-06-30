using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class WorkflowParticipate
{
    public uint Id { get; set; }

    public uint Index { get; set; }

    public uint ModuleSrcId { get; set; }

    public uint SrcId { get; set; }

    public string Uid { get; set; } = null!;

    public string Pid { get; set; } = null!;
}
