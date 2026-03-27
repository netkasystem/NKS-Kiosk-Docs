using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SkillTraining
{
    public uint TrainingId { get; set; }

    public uint StaffId { get; set; }

    public uint CaseSubCategoryId { get; set; }

    public string? TrainingCode { get; set; }

    public string? TrainingCourse { get; set; }
}

