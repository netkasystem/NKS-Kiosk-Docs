using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Associated
{
    public uint Id { get; set; }

    public uint ModuleSrcId { get; set; }

    public uint SrcId { get; set; }

    public uint ModuleDstId { get; set; }

    public uint DstId { get; set; }

    public uint UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }
}

