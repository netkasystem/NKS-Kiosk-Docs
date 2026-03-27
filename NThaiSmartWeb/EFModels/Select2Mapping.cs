using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Select2Mapping
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    public string PkKey { get; set; } = null!;

    public string Filter { get; set; } = null!;

    public string QuerySearch { get; set; } = null!;

    public string QueryWhere { get; set; } = null!;

    public string QueryGroup { get; set; } = null!;

    public string QueryOrderBy { get; set; } = null!;

    public string QueryCount { get; set; } = null!;
}

