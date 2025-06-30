using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Department
{
    public uint DepartmentId { get; set; }

    public string DepartmentTitle { get; set; } = null!;

    public uint DepartmentSequence { get; set; }
}
