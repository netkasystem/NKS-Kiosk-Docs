using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class AdminMessage
{
    public uint Id { get; set; }

    public string Subject { get; set; } = null!;

    public string Message { get; set; } = null!;

    public DateTime Startdate { get; set; }

    public DateTime Enddate { get; set; }

    public uint DepartmentId { get; set; }

    public uint SectionId { get; set; }

    public uint CreateBy { get; set; }

    public DateTime CreateDate { get; set; }
}
