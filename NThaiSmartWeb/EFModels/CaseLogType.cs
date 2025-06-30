using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CaseLogType
{
    public uint CaseLogTypeId { get; set; }

    public string CaseLogTypeTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public uint CaseLogCategoryId { get; set; }

    public virtual ICollection<CaseLog> CaseLog { get; set; } = new List<CaseLog>();

    public virtual CaseLogCategory CaseLogCategory { get; set; } = null!;
}
