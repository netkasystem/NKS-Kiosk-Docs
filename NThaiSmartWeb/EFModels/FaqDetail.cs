using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class FaqDetail
{
    public uint Id { get; set; }

    public uint CategoryId { get; set; }

    public string Quastion { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public uint CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public string Tags { get; set; } = null!;

    public uint LikeCount { get; set; }

    public uint DislikeCount { get; set; }

    public uint Stat { get; set; }
}
