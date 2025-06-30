using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class ServiceType
{
    public uint ServiceTypeId { get; set; }

    public string ServiceTypeTitle { get; set; } = null!;

    public ulong IsImpactService { get; set; }

    public uint CaseIdFormat { get; set; }

    public ulong Inactive { get; set; }

    public virtual CaseIdFormat CaseIdFormatNavigation { get; set; } = null!;
}
