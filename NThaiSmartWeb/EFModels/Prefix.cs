using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Prefix
{
    public uint PrefixId { get; set; }

    public string PrefixTitle { get; set; } = null!;

    public uint PrefixSequence { get; set; }

    public virtual ICollection<Contact> Contact { get; set; } = new List<Contact>();
}

