param(
    [string[]]$Tables,   # ระบุ table เช่น -Tables user,order
    [switch]$Temp        # ใช้โหมด Temp เช่น -Temp
)

$ErrorActionPreference = "Stop"
$totalSw = [System.Diagnostics.Stopwatch]::StartNew()

Write-Host "⏳ Start EF Core Scaffold..."

Write-Host "Tables param: $Tables"

$basePath = $PSScriptRoot

# Connection String
$NSDXConnectionString = "Server=10.1.8.59;Port=3306;Database=n_smart_kiosk;User=nkssdsk;Password=Ay2!BGur8;TreatTinyAsBoolean=true;Convert Zero Datetime=True;Connection Timeout=600;default command timeout=600;CharSet=utf8mb4"
Write-Host " Data base : $NSDXConnectionString"

# Default (ของจริง)
$contextName = "DBContext"
$outputPath  = Join-Path $basePath "EFModels"

# Temp Mode
if ($Temp) {

    Write-Host "🧪 TEMP MODE ENABLED"

    $contextName = "DbContextTemp"
    $outputPath  = Join-Path $basePath "TempModels"

    # Create folder if not exists
    if (!(Test-Path $outputPath)) {
        New-Item -ItemType Directory -Path $outputPath | Out-Null
    }

    # 🔥 ลบไฟล์ทั้งหมดใน TempModels ก่อน scaffold
    Write-Host "🗑 Clearing TempModels..."
    Get-ChildItem -Path $outputPath -Recurse -File | Remove-Item -Force
}

# Base command
$cmd = @(
    "ef", "dbcontext", "scaffold",
    $NSDXConnectionString,
    "Pomelo.EntityFrameworkCore.MySql",
    "-o", $outputPath,
    "-c", $contextName,
    "-f",
    "--no-onconfiguring",
    "--no-pluralize"
)

# Partial Mode (เลือก table)
if ($Tables -and $Tables.Count -gt 0) {

    Write-Host "📌 Partial Scaffold: $($Tables -join ', ')"

    foreach ($table in $Tables) {
        $cmd += "--table"
        $cmd += $table.Trim()
    }

    # ถ้าไม่ใช่ Temp → กัน Context พัง
    if (-not $Temp) {
        $cmd += "--no-context"
        Write-Host "🔒 Safe Mode: Skip DbContext"
    }
}
else {
    Write-Host "📦 Full Scaffold (All Tables)"
}

Write-Host "▶ Running: dotnet $($cmd -join ' ')"
$sw = [System.Diagnostics.Stopwatch]::StartNew()
dotnet @cmd
$sw.Stop()
Write-Host "⏱ Scaffold: $($sw.Elapsed.ToString('mm\:ss\.ff'))"

if ($Temp) {
    # 🔄 เปลี่ยน namespace ก่อน
    Write-Host "🔄 Updating namespace..."
    $sw = [System.Diagnostics.Stopwatch]::StartNew()

    Get-ChildItem -Path $outputPath -Recurse -Filter *.cs | ForEach-Object {
        (Get-Content $_.FullName -Raw) `
            -replace 'namespace NThaiSmartWeb.TempModels', 'namespace NThaiSmartWeb.EFModels' `
            | Set-Content $_.FullName
    }

    $sw.Stop()
    Write-Host "✅ Namespace updated to NSDX.Data.EFModels ($($sw.Elapsed.ToString('mm\:ss\.ff')))"

    # 📦 Move models
    Write-Host "📦 Moving models to EFModels..."
    $sw = [System.Diagnostics.Stopwatch]::StartNew()

    $targetPath = Join-Path $basePath "EFModels"

    if (!(Test-Path $targetPath)) {
        New-Item -ItemType Directory -Path $targetPath | Out-Null
    }

    $allowed = @()

    if ($Tables -and $Tables.Count -gt 0) {
        $allowed = $Tables | ForEach-Object {
            $name = (($_ -split "_") | ForEach-Object {
                $_.Substring(0,1).ToUpper() + $_.Substring(1)
            }) -join ""

            $name.ToLower()
        }
    }


    Get-ChildItem $outputPath -Filter *.cs |
    Where-Object {
        if ($_.Name -eq "DbContextTemp.cs") { return $false }

        $name = ($_.BaseName).ToLower()

        if ($allowed.Count -gt 0) {
            return $allowed -contains $name
        }

        return $true
    } |
    ForEach-Object {

        $dest = Join-Path $targetPath $_.Name

        Write-Host "➡ Replacing $($_.Name)"

        Copy-Item $_.FullName $dest -Force
    }

    $sw.Stop()
    Write-Host "✅ Models moved to EFModels ($($sw.Elapsed.ToString('mm\:ss\.ff')))"


    # Merging DbContext
    Write-Host "🔄 Merging DbContext..."
    $sw = [System.Diagnostics.Stopwatch]::StartNew()

    $tempContext = Join-Path $outputPath "DbContextTemp.cs"
    $mainContext = Join-Path $basePath "EFModels\DBContext.cs"

    if (!(Test-Path $tempContext)) {
        Write-Host "❌ DbContextTemp.cs not found. Scaffold may have failed." -ForegroundColor Red
        return
    }

   if (!(Test-Path $mainContext)) {
        Write-Host "❌ DBContext.cs not found." -ForegroundColor Red
        return
   }

    $tempContent = Get-Content $tempContext -Raw
    $mainContent = Get-Content $mainContext -Raw

    Write-Host "🔄 Merging DbSet..."

    # หา DbSet จาก temp context
    $dbsets = [regex]::Matches($tempContent,'public\s+virtual\s+DbSet<([^>]+)>\s+([A-Za-z0-9_]+)\s*\{\s*get;\s*set;\s*\}')

    foreach ($set in $dbsets) {

        $entity = $set.Groups[1].Value
        $property = $set.Groups[2].Value
        $line = $set.Value

        Write-Host "➡ Checking DbSet<$entity>"
        $pattern = "DbSet<$entity>"

        if ($mainContent -match $pattern) {
            Write-Host "   ✔ Exists"
        } else {
            Write-Host "   ➕ Adding DbSet"
            $mainContent = $mainContent -replace "(public\s+partial\s+class\s+DBContext[^{]*\{)","`$1`n        $line"
        }
    }

    $entityPattern = 'modelBuilder\.Entity<([^>]+)>\(entity\s*=>\s*\{.*?\}\);'
    # หา entity blocks
    $matches = [regex]::Matches( $tempContent, $entityPattern, [System.Text.RegularExpressions.RegexOptions]::Singleline)

    foreach ($m in $matches) {

        $entityName = $m.Groups[1].Value
        $block = $m.Value

        Write-Host "➡ Processing entity $entityName"
        $pattern = "modelBuilder\.Entity<$entityName>\(entity\s*=>\s*\{[\s\S]*?\}\);"

        if ($mainContent -match $pattern) {
            Write-Host "   🔁 Replacing existing entity"
            $mainContent = [regex]::Replace($mainContent,$pattern,[System.Text.RegularExpressions.MatchEvaluator]{ param($x) $block })

        } else {
            Write-Host "   ➕ Adding new entity"
            $mainContent = $mainContent -replace "(OnModelCreating\(ModelBuilder modelBuilder\)\s*\{)","`$1`n$block`n"
        }
    }

    Set-Content $mainContext $mainContent

    $sw.Stop()
    Write-Host "✅ DbContext merged ($($sw.Elapsed.ToString('mm\:ss\.ff')))"

}

$totalSw.Stop()
Write-Host "✅ Done. Total: $($totalSw.Elapsed.ToString('mm\:ss\.ff'))"
