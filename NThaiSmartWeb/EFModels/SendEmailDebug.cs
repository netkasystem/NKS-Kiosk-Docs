using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class SendEmailDebug
{
    public uint Id { get; set; }

    public string Action { get; set; } = null!;

    public DateTime UpdatedDate { get; set; }

    public string CaseId { get; set; } = null!;
}

