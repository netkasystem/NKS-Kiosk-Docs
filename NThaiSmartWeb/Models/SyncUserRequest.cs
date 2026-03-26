
public class SyncUserRequest
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public uint? LevelId { get; set; }
    public string? Objectsid { get; set; }
    public string? LdapPath { get; set; }
    public string? LdapName { get; set; }
    public uint? Useraccountcontrol { get; set; }
}