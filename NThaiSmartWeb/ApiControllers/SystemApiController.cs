using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NThaiSmartWeb.EFModels;

namespace NThaiSmartWeb.ApiControllers;

[ApiController]
[Route("api/[controller]")]
public partial class SystemApiController : ControllerBase
{
    private readonly KioskContext _context;

    public SystemApiController(KioskContext context)
    {
        _context = context;
    }

    [HttpPost("synckiosk")]
    public async Task<IActionResult> SyncKiosk([FromBody] SyncKioskRequest request)
    {
        if (request == null)
            return BadRequest("Missing request body");

        if (request.User == null)
            return BadRequest("user required");

        if (request.Kiosk == null)
            return BadRequest("kiosk required");

        if (string.IsNullOrWhiteSpace(request.User.Username))
            return BadRequest("username required");

        if (request.Kiosk.KioskId is null && string.IsNullOrWhiteSpace(request.Kiosk.KioskCode))
            return BadRequest("kiosk_id or kiosk_code required");

        var region = await ResolveRegionAsync(request.Region);
        if (request.Region != null && region == null)
            return BadRequest("region not found");

        var kiosk = await _context.Kiosk.FirstOrDefaultAsync(k =>
            (request.Kiosk.KioskId.HasValue && k.Id == request.Kiosk.KioskId.Value) ||
            (!string.IsNullOrWhiteSpace(request.Kiosk.KioskCode) && k.KioskCode == request.Kiosk.KioskCode));

        var kioskCreated = false;
        if (kiosk == null)
        {
            if (string.IsNullOrWhiteSpace(request.Kiosk.KioskCode))
                return BadRequest("kiosk_code required for new kiosk");

            kiosk = new Kiosk
            {
                KioskCode = request.Kiosk.KioskCode.Trim(),
                KioskName = request.Kiosk.KioskName ?? string.Empty,
                Description = request.Kiosk.Description,
                Address = request.Kiosk.Address ?? string.Empty,
                Latitude = request.Kiosk.Latitude ?? string.Empty,
                Longitude = request.Kiosk.Longitude ?? string.Empty,
                ContactName = request.Kiosk.ContactName ?? string.Empty,
                ContactEmail = request.Kiosk.ContactEmail ?? string.Empty,
                ContactTel = request.Kiosk.ContactTel ?? string.Empty,
                Inactive = request.Kiosk.Inactive,
                FirstBoot = request.Kiosk.FirstBoot,
                ActivationStatus = request.Kiosk.ActivationStatus,
                ActivationNote = request.Kiosk.ActivationNote ?? string.Empty,
                FactoryImageVersion = request.Kiosk.FactoryImageVersion ?? string.Empty,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                KioskImage = request.Kiosk.KioskImage ?? string.Empty,
                ProvinceId = request.Kiosk.ProvinceId ?? 0,
                SerialNumber = request.Kiosk.SerialNumber ?? string.Empty,
                MacAddress = request.Kiosk.MacAddress ?? string.Empty,
                HardwareHash = request.Kiosk.HardwareHash ?? string.Empty,
                ContractId = request.Kiosk.ContractId,
                RegionId = region?.RegionId ?? request.Kiosk.RegionId
            };

            _context.Kiosk.Add(kiosk);
            await _context.SaveChangesAsync();
            kioskCreated = true;
        }
        else
        {
            if (!string.IsNullOrWhiteSpace(request.Kiosk.KioskCode))
                kiosk.KioskCode = request.Kiosk.KioskCode.Trim();
            if (request.Kiosk.KioskName != null)
                kiosk.KioskName = request.Kiosk.KioskName;
            if (request.Kiosk.Description != null)
                kiosk.Description = request.Kiosk.Description;
            if (request.Kiosk.Address != null)
                kiosk.Address = request.Kiosk.Address;
            if (request.Kiosk.Latitude != null)
                kiosk.Latitude = request.Kiosk.Latitude;
            if (request.Kiosk.Longitude != null)
                kiosk.Longitude = request.Kiosk.Longitude;
            if (request.Kiosk.ContactName != null)
                kiosk.ContactName = request.Kiosk.ContactName;
            if (request.Kiosk.ContactEmail != null)
                kiosk.ContactEmail = request.Kiosk.ContactEmail;
            if (request.Kiosk.ContactTel != null)
                kiosk.ContactTel = request.Kiosk.ContactTel;
            if (request.Kiosk.Inactive.HasValue)
                kiosk.Inactive = request.Kiosk.Inactive;
            if (request.Kiosk.FirstBoot.HasValue)
                kiosk.FirstBoot = request.Kiosk.FirstBoot;
            if (request.Kiosk.ActivationStatus.HasValue)
                kiosk.ActivationStatus = request.Kiosk.ActivationStatus;
            if (request.Kiosk.ActivationNote != null)
                kiosk.ActivationNote = request.Kiosk.ActivationNote;
            if (request.Kiosk.FactoryImageVersion != null)
                kiosk.FactoryImageVersion = request.Kiosk.FactoryImageVersion;
            if (request.Kiosk.KioskImage != null)
                kiosk.KioskImage = request.Kiosk.KioskImage;
            if (request.Kiosk.ProvinceId.HasValue)
                kiosk.ProvinceId = request.Kiosk.ProvinceId.Value;
            if (request.Kiosk.SerialNumber != null)
                kiosk.SerialNumber = request.Kiosk.SerialNumber;
            if (request.Kiosk.MacAddress != null)
                kiosk.MacAddress = request.Kiosk.MacAddress;
            if (request.Kiosk.HardwareHash != null)
                kiosk.HardwareHash = request.Kiosk.HardwareHash;
            if (request.Kiosk.ContractId.HasValue)
                kiosk.ContractId = request.Kiosk.ContractId;
            if (region != null)
                kiosk.RegionId = region.RegionId;
            else if (request.Kiosk.RegionId.HasValue)
                kiosk.RegionId = request.Kiosk.RegionId;

            kiosk.UpdatedAt = DateTime.UtcNow;
        }

        var user = await _context.User.FirstOrDefaultAsync(u => u.Username == request.User.Username);
        var userCreated = false;
        if (user == null)
        {
            user = new User
            {
                Username = request.User.Username.Trim(),
                Password = request.User.Password ?? string.Empty,
                LevelId = request.User.LevelId ?? 0,
                KioskId = kiosk.Id,
                Objectsid = request.User.Objectsid ?? string.Empty,
                LdapPath = request.User.LdapPath ?? string.Empty,
                LdapName = request.User.LdapName ?? string.Empty,
                Useraccountcontrol = request.User.Useraccountcontrol ?? 0,
                CreatedDatetime = DateTime.UtcNow,
                UpdatedDatetime = DateTime.UtcNow
            };

            _context.User.Add(user);
            userCreated = true;
        }
        else
        {
            user.KioskId = kiosk.Id;
            if (request.User.Password != null)
                user.Password = request.User.Password;
            if (request.User.LevelId.HasValue)
                user.LevelId = request.User.LevelId.Value;
            if (request.User.Objectsid != null)
                user.Objectsid = request.User.Objectsid;
            if (request.User.LdapPath != null)
                user.LdapPath = request.User.LdapPath;
            if (request.User.LdapName != null)
                user.LdapName = request.User.LdapName;
            if (request.User.Useraccountcontrol.HasValue)
                user.Useraccountcontrol = request.User.Useraccountcontrol.Value;

            user.UpdatedDatetime = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();

        return Ok(new
        {
            kiosk_id = kiosk.Id,
            kiosk_status = kioskCreated ? "created" : "updated",
            user_status = userCreated ? "created" : "updated"
        });
    }

    private async Task<Region?> ResolveRegionAsync(SyncRegionRequest? regionRequest)
    {
        if (regionRequest == null)
            return null;

        Region? region = null;
        if (regionRequest.RegionId.HasValue)
            region = await _context.Region.FirstOrDefaultAsync(r => r.RegionId == regionRequest.RegionId.Value);
        else if (!string.IsNullOrWhiteSpace(regionRequest.RegionSite))
            region = await _context.Region.FirstOrDefaultAsync(r => r.RegionSite == regionRequest.RegionSite);

        if (region == null)
            return null;

        if (!string.IsNullOrWhiteSpace(regionRequest.RegionSite))
            region.RegionSite = regionRequest.RegionSite;

        return region;
    }
}