using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Contact
{
    public uint ContactId { get; set; }

    public uint? PrefixId { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public uint? GenderId { get; set; }

    public string? Position { get; set; }

    public string? Department { get; set; }

    public string? Mobile { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public uint? SiteId { get; set; }

    public uint? CustomerId { get; set; }

    public string? Comment { get; set; }

    public byte Inactive { get; set; }

    public string? ProfileImage { get; set; }

    public byte InactiveChatbot { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Prefix? Prefix { get; set; }

    public virtual Site? Site { get; set; }
}
