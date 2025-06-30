using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CaseTypeCustomSetup
{
    public uint Id { get; set; }

    public uint CaseTypeId { get; set; }

    public string MandatoryField { get; set; } = null!;

    public string OptionalField { get; set; } = null!;
}
