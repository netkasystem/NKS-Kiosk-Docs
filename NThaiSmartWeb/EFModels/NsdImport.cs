using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

/// <summary>
/// Mapping table with webpage
/// </summary>
public partial class NsdImport
{
    public uint Id { get; set; }

    public string Tbname { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string UniqueField { get; set; } = null!;
}
