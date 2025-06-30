using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Watcher
{
    public uint Id { get; set; }

    public uint ModuleId { get; set; }

    public uint CaseId { get; set; }

    public string StaffId { get; set; } = null!;

    public string ContactId { get; set; } = null!;

    public string SupplierContactId { get; set; } = null!;
}
