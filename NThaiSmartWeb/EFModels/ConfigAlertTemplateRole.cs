using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ConfigAlertTemplateRole
{
    public uint Id { get; set; }

    public uint ConfigLertTemplateId { get; set; }

    public string AlertRoleId { get; set; } = null!;

    public uint TemplateId { get; set; }
}
