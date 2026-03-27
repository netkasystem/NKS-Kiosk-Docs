using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class NksfsrvFileCabinet
{
    public uint Id { get; set; }

    public string? Filename { get; set; }

    public string? Category { get; set; }

    public string? Username { get; set; }

    public string? Description { get; set; }

    public byte[]? Mass { get; set; }

    public string? CreateDateTime { get; set; }

    public uint? FileSize { get; set; }

    public string? Rng { get; set; }

    public string? Password { get; set; }
}

