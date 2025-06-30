using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Translate
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Code { get; set; }

    public string? Icon { get; set; }

    public string? Words { get; set; }
}
