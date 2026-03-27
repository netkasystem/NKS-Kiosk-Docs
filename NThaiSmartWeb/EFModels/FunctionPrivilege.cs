using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class FunctionPrivilege
{
    public uint Id { get; set; }

    public uint LevelId { get; set; }

    public bool AllowCreate { get; set; }

    public bool AllowDelete { get; set; }

    public bool AllowClose { get; set; }

    public bool AllowReview { get; set; }

    public bool AllowPrint { get; set; }

    public bool AllowExport { get; set; }

    public bool AllowPriority { get; set; }

    public bool AllowReadOnly { get; set; }

    public bool AllowEdit { get; set; }

    public uint ModuleId { get; set; }
}

