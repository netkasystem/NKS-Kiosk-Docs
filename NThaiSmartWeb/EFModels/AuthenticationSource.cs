using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class AuthenticationSource
{
    public uint Id { get; set; }

    public string SourceName { get; set; } = null!;

    public string SourceProvider { get; set; } = null!;

    public string ServerName { get; set; } = null!;

    public ushort ServerPort { get; set; }

    public ulong EnableTls { get; set; }

    public ushort? SourceVersion { get; set; }

    public string BaseDn { get; set; } = null!;

    public ulong SourceAnonymous { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? SourceIdentifier { get; set; }

    public string? SourceAdditional { get; set; }

    public uint CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public ulong Inactive { get; set; }
}

