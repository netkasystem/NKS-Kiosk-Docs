public class NationalCardModel
{
    public uint KioskId { get; set; }
    public string KioskCode { get; set; }
    public string citizenID { get; set; }
    public string fullNameTH { get; set; }
    public string fullNameEN { get; set; }
    public string dateOfBirth { get; set; }
    public string issueDate { get; set; }
    public string expireDate { get; set; }
    public string address { get; set; }
    public string issuer { get; set; }
    public string photo { get; set; }
    public string face_capture { get; set; } 
    public string CustomData { get; set; } 
}
public class EncryptedPayload
{
    public string EncrypString { get; set; }
    public string EncrypUpdatedData { get; set; }
    public string EncrypCustomDataData { get; set; }
}
public class EncryptedIntegrateNdppData
{
    public string EncryptedINDPPString { get; set; } 
}
 
public class IntegrateNdppData
{
    public string IntegrateNdppId { get; set; } 
    public string Firstname { get; set; } 
    public string Lastname { get; set; } 
    public string Email { get; set; } 
    public string IntegrateUrl { get; set; } 
    public List<uint> PurposeOption { get; set; } 
}
 