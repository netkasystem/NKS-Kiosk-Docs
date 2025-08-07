using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

/// <summary>
/// ตารางเก็บข้อมูล template สำหรับ setup kiosk script
/// </summary>
public partial class KioskSetup
{
    /// <summary>
    /// รหัสอัตโนมัติของสคริปต์
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// รหัสอ้างอิงของสคริปต์ เช่น setup-kiosk-v1
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// ชื่อไฟล์ shell script เช่น setup-kiosk.sh
    /// </summary>
    public string Filename { get; set; } = null!;

    /// <summary>
    /// ชื่อของสคริปต์ เช่น Kiosk Ubuntu Install
    /// </summary>
    public string Name { get; set; } = null!;

    public string UrlRegion { get; set; } = null!;

    /// <summary>
    /// รายละเอียดเพิ่มเติมของสคริปต์หรือวิธีใช้งาน
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// เนื้อ shell script ที่จะรันใน kiosk
    /// </summary>
    public string ScriptContent { get; set; } = null!;

    /// <summary>
    /// ระบบปฏิบัติการที่รองรับ เช่น ubuntu22.04, debian
    /// </summary>
    public string? OsType { get; set; }

    /// <summary>
    /// เวอร์ชันของสคริปต์ เช่น v1.0.3 หรือ latest
    /// </summary>
    public string? Version { get; set; }

    /// <summary>
    /// สถานะการใช้งาน (1=ใช้งาน, 0=ไม่ใช้งาน)
    /// </summary>
    public bool? IsActive { get; set; }

    /// <summary>
    /// คำค้นหรือหมวดหมู่ เช่น docker,cardreader,auto-setup
    /// </summary>
    public string? Tags { get; set; }

    /// <summary>
    /// วันที่สร้างข้อมูล
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// วันที่แก้ไขล่าสุด
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}
