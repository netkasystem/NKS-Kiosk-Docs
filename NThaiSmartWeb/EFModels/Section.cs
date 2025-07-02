using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Section
{
    public uint SectionId { get; set; }

    public string SectionTitle { get; set; } = null!;

    public uint DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;
}
