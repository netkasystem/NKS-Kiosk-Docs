<#
    .SYNOPSIS
        สคริปต์สำหรับสร้าง Entity Framework Core Model (Scaffold) จากฐานข้อมูล MySQL

    .DESCRIPTION
        ใช้คำสั่ง dotnet ef dbcontext scaffold เพื่อ reverse engineer schema จากฐานข้อมูล MySQL
        และแปลงเป็นไฟล์ entity ในโปรเจกต์ .NET

    .PARAMETERS
        - Connection String : ระบุค่าการเชื่อมต่อ MySQL
        - Provider          : ใช้ Pomelo.EntityFrameworkCore.MySql สำหรับ MySQL
        - -o                : โฟลเดอร์ที่ใช้เก็บคลาส Entity ที่ generate ขึ้น
        - -c                : ชื่อของ DbContext ที่ต้องการให้ generate
        - -f                : บังคับเขียนทับไฟล์เดิม
        - --no-onconfiguring: ไม่ generate เมธอด OnConfiguring ใน DbContext
        - --no-pluralize    : ไม่ใช้การแปลงชื่อเป็นพหูพจน์ (เช่น ไม่เปลี่ยน `User` เป็น `Users`)

.NOTES
    ก่อนใช้งานควรติดตั้ง EF CLI ด้วยคำสั่ง:
        dotnet tool install --global dotnet-ef

    ############################################
    ##########     วิธีการรันสคริปต์     ##########
    ############################################

    🔹 หากคุณใช้ Visual Studio:
        1. ไปที่เมนู **Tools** > **NuGet Package Manager** > **Package Manager Console**
        2. ลองพิมพ์ PWD เพื่อตรวจสอบให้แน่ใจว่า **Path อยู่ที่ root ของโปรเจกต์** (เช่น NSDX-NT-CATCSS)
        3. จากนั้นรันคำสั่งต่อไปนี้:
            cd NSDX.Data
            .\generate-entities.ps1

    🔹 หากใช้ PowerShell ทั่วไป:
        1. เปิด PowerShell แล้วเปลี่ยน directory ไปยัง root ของโปรเจกต์
        2. จากนั้นเข้าไปที่โฟลเดอร์ `NSDX.Data` และรันสคริปต์:
            cd NSDX.Data
            .\generate-entities.ps1
#>

Write-Host "⏳ เริ่มการสร้าง Entity Framework Core Models จากฐานข้อมูล..."

# ใช้ path ของไฟล์นี้เอง เป็น base
$basePath = $PSScriptRoot

# Default command
# dotnet ef dbcontext scaffold "Server=10.1.8.49;Port=3306;Database=css;User=nkssdsk;Password=Ay2!BGur8;TreatTinyAsBoolean=true;Convert Zero Datetime=True;Connection Timeout=600;default command timeout=600" "Pomelo.EntityFrameworkCore.MySql" -o EFModels -c DBContext -f --no-onconfiguring --no-pluralize

# Define the connection string as a variable
$connectionString = "Server=10.1.8.59;Port=3306;Database=n_smart_kiosk;User=nkssdsk;Password=Ay2!BGur8;TreatTinyAsBoolean=true;Convert Zero Datetime=True;Connection Timeout=600;default command timeout=600"
# $connectionString = "Server=localhost;Port=3306;Database=css;User=root;Password=root;TreatTinyAsBoolean=true;Convert Zero Datetime=True;Connection Timeout=600;default command timeout=600"
Write-Host " Data base : $connectionString" 

# Run the scaffold command
dotnet ef dbcontext scaffold `
    $connectionString `
    "Pomelo.EntityFrameworkCore.MySql" `
    -o "$basePath\EFModels" `
    -c DBContext `
    -f --no-onconfiguring --no-pluralize

Write-Host "✅ สร้าง Model เสร็จสิ้นแล้ว"
