using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Skill
{
    public uint SkillId { get; set; }

    public uint StaffId { get; set; }

    public uint CaseSubCategoryId { get; set; }

    public uint SkillLevelId { get; set; }

    public uint TierId { get; set; }
}
