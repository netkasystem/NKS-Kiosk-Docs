using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CaseType
{
    public uint CaseTypeId { get; set; }

    public string CaseTypeTitle { get; set; } = null!;

    public string CaseTypeDescription { get; set; } = null!;

    public uint IsAlert { get; set; }

    public byte Inactive { get; set; }

    public string ImageName { get; set; } = null!;

    public string TeamId { get; set; } = null!;

    public uint OwnerId { get; set; }
}

