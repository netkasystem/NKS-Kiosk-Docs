#!/bin/bash
set +o histexpand

# 🔧 กำหนดค่าตัวแปร
MYSQLDUMP="C:/Users/Kwanchai_RD/AppData/Roaming/DBeaverData/drivers/clients/mysql_8/win/mysqldump.exe"
MYSQL="C:/Users/Kwanchai_RD/AppData/Roaming/DBeaverData/drivers/clients/mysql_8/win/mysql.exe"
DB_HOST_SRC="10.1.8.59"
DB_PORT_SRC="3306"
DB_USER_SRC="nkssdsk"
DB_PASS_SRC="Ay2!BGur8"

DB_HOST_DES="localhost"
DB_PORT_DES="3306"
DB_USER_DES="root"
DB_PASS_DES="root"

DB_NAME="n_smart_kiosk"
DUMP_FILE="C:/Users/kwanchai/dump-${DB_NAME}-$(date +%Y%m%d%H%M).sql"

# 📦 Dump SQL (schema only)
echo "🔄 Dumping database schema to $DUMP_FILE..."
"$MYSQLDUMP" -h $DB_HOST_SRC -P $DB_PORT_SRC -u $DB_USER_SRC -p"$DB_PASS_SRC" \
  --skip-lock-tables --column-statistics=0 --routines \
  --add-drop-table --disable-keys --extended-insert --no-data --comments $DB_NAME > "$DUMP_FILE"

# ลบ DEFINER ออก
echo "🔄 ลบ DEFINER และ SQL SECURITY DEFINER ออกจากไฟล์ dump..."
sed -i.bak -e 's/DEFINER=`[^`]*`@`[^`]*`//g' -e 's/SQL SECURITY DEFINER//g' "$DUMP_FILE"
echo "✅ ลบ DEFINER และ SQL SECURITY DEFINER เสร็จแล้ว"

# ตรวจสอบว่ามี DEFINER เหลือไหม (optional)
echo "🔎 ตรวจสอบว่ามี DEFINER หรือ SQL SECURITY DEFINER เหลือไหม..."
grep -Ei "DEFINER|SQL SECURITY DEFINER" "$DUMP_FILE" && echo "⚠️ ยังพบ DEFINER หรือ SQL SECURITY DEFINER ในไฟล์" || echo "✅ ไม่มี DEFINER หรือ SQL SECURITY DEFINER เหลือในไฟล์"

# 🗑 ลบ database เดิมและสร้างใหม่
echo "🧨 Dropping and recreating database on localhost..."
"$MYSQL" -h $DB_HOST_DES -P $DB_PORT_DES -u $DB_USER_DES -p"$DB_PASS_DES" \
  -e "DROP DATABASE IF EXISTS $DB_NAME; CREATE DATABASE $DB_NAME CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;"

#DUMP_FILE="C:/Users/kwanchai/dump-${DB_NAME}-202507291433.sql"
# ♻️ Restore to localhost
echo "♻️ Restoring database to localhost..."
"$MYSQL" -h $DB_HOST_DES -P $DB_PORT_DES -u $DB_USER_DES -p"$DB_PASS_DES" $DB_NAME < "$DUMP_FILE"

# ⚙️ Scaffold EF Core Model
echo "🛠️ Scaffold EF Core..."
dotnet ef dbcontext scaffold \
  "Server=localhost;Port=$DB_PORT_DES;Database=$DB_NAME;User=$DB_USER_DES;Password=$DB_PASS_DES;TreatTinyAsBoolean=true;Convert Zero Datetime=True;Connection Timeout=600;default command timeout=600" \
  "Pomelo.EntityFrameworkCore.MySql" \
  -o EFModels \
  -c DBContext \
  -f --no-onconfiguring --no-pluralize

echo "✅ Done!"
read -p "กด Enter เพื่อออก..."
