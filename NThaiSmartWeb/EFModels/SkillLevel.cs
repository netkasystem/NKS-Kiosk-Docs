using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SkillLevel
{
    public uint SkillLevelId { get; set; }

    public string SkillLevelTitle { get; set; } = null!;

    public string Description { get; set; } = null!;
}
