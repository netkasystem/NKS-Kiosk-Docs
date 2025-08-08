using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class KioskControlCommand
{
    /// <summary>
    /// Primary key
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// Command name, e.g. &quot;Open Google&quot;, &quot;Restart&quot;
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Shell script or command text
    /// </summary>
    public string CommandText { get; set; } = null!;

    /// <summary>
    /// Additional description (optional)
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Whether this command is enabled or not
    /// </summary>
    public bool? IsEnabled { get; set; }

    /// <summary>
    /// Allow passing additional arguments or not
    /// </summary>
    public bool? AllowArgs { get; set; }

    /// <summary>
    /// Record creation timestamp
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Record last update timestamp
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}
