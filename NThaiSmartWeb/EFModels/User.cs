using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class User
{
    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public string? PasswordResetToken { get; set; }

    public DateTime? PasswordUpdateDate { get; set; }

    public uint? StaffId { get; set; }

    public uint? ContactId { get; set; }

    public uint? SupplierContactId { get; set; }

    public uint LevelId { get; set; }

    public ulong ReadOnly { get; set; }

    public ulong Print { get; set; }

    public ulong Export { get; set; }

    public ulong CreateCase { get; set; }

    public ulong AssignCase { get; set; }

    public ulong AcceptCase { get; set; }

    public ulong ResponseCase { get; set; }

    public ulong OnsiteCase { get; set; }

    public ulong InProgressCase { get; set; }

    public ulong ResolveCase { get; set; }

    public ulong PendingCase { get; set; }

    public ulong CloseCase { get; set; }

    public ulong DeleteCase { get; set; }

    public ulong EditLog { get; set; }

    public ulong AddKm { get; set; }

    public uint ApproveKm { get; set; }

    public DateTime? CreatedDatetime { get; set; }

    public DateTime? UpdatedDatetime { get; set; }

    public uint? CreatedBy { get; set; }

    public uint? UpdatedBy { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public ulong Disable { get; set; }

    public ulong LockScreen { get; set; }

    public uint LockNum { get; set; }

    public uint? ChangepwDay { get; set; }

    public string Objectsid { get; set; } = null!;

    public string? UserLineId { get; set; }

    public string LdapPath { get; set; } = null!;

    public string LdapName { get; set; } = null!;

    public uint Useraccountcontrol { get; set; }
}
