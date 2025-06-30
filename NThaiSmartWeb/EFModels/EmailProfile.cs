using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class EmailProfile
{
    public uint EmailProfileId { get; set; }

    public string ProfileName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public uint TemplateTypeId { get; set; }
}
