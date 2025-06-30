using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CaseLogCategory
{
    public uint CaseLogCategoryId { get; set; }

    public string CaseLogCategoryTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<CaseLogType> CaseLogType { get; set; } = new List<CaseLogType>();
}
