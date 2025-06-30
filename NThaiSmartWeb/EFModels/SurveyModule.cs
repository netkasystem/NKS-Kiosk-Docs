using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SurveyModule
{
    public uint Id { get; set; }

    public uint ModuleId { get; set; }

    public string TableName { get; set; } = null!;
}
