using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class AnalyticalWhatif
{
    public uint WhatifId { get; set; }

    public string? Assumption { get; set; }

    public string? Consideration { get; set; }

    public string? Dependencie { get; set; }

    public string? Lever { get; set; }

    public uint WhatifSequence { get; set; }
}

