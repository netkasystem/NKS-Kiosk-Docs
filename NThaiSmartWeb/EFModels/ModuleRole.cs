using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ModuleRole
{
    public uint Id { get; set; }

    public uint? ModuleId { get; set; }

    public string? RoleName { get; set; }

    public string? Table { get; set; }

    public string? FieldSelect { get; set; }

    public string? FieldKey { get; set; }

    public uint? IsStaff { get; set; }

    public uint? IsContact { get; set; }
}

