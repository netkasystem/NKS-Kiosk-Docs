using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Gender
{
    public uint GenderId { get; set; }

    public string GenderTitle { get; set; } = null!;

    public uint GenderSequence { get; set; }
}

