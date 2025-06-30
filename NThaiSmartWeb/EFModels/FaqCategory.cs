using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class FaqCategory
{
    public uint Id { get; set; }

    public string CategoryTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Favicon { get; set; } = null!;
}
