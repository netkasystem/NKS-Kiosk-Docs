public class SyncKioskRequest
{
    public SyncUserRequest? User { get; set; }
    public SyncKioskInfoRequest? Kiosk { get; set; }
    public SyncRegionRequest? Region { get; set; }
}