using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class CaseIdFormat
{
    public uint Id { get; set; }

    public string CaseIdTitle { get; set; } = null!;

    public string CaseIdFormat1 { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<ServiceType> ServiceType { get; set; } = new List<ServiceType>();
}

