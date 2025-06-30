using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class TestStartFinish
{
    public int Id { get; set; }

    public DateTime? DateStart { get; set; }

    public DateTime? DateFinish { get; set; }
}
