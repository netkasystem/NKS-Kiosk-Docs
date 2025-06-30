#!/bin/bash

# Usage: ./build-push.sh 1.0.0, latest.dev

set -e
trap handle_error ERR

# ตรวจสอบว่าให้ tag version มาหรือยัง ถ้ายังให้ใช้ default
TAG=${1:-"latest.dev"}

# แสดงข้อความเตือนถ้าไม่ได้ส่งมา (ทางเลือก)
if [ -z "$1" ]; then
  echo "⚠️  ไม่ได้ระบุ tag version — จะใช้ค่า default: $TAG"
fi

ROOT_DIR=$(cd "$(dirname "$0")/.." && pwd)
IMAGE_NAME=netkaofficialhub/nthaismartweb:$TAG
PROJECT_NAME="N-ThaiSmart-Web"

# สร้างไฟล์ BuildVersion.cs (ถ้าต้องใช้)
echo "public static class BuildVersion {
        public const string Value = \"$TAG\";
        public const string BuildDate = \"$(date '+%Y-%m-%d %H:%M:%S')\";
        public const string CreateProjYear = \"2025\";
    }
" > "$ROOT_DIR/$PROJECT_NAME/BuildVersion.cs"

echo "📂 Working dir: $ROOT_DIR"
echo "🔧 กำลัง build Docker image: $IMAGE_NAME"

docker build -f "$ROOT_DIR/$PROJECT_NAME/Dockerfile" -t $IMAGE_NAME "$ROOT_DIR"
if [ $? -ne 0 ]; then
  echo "❌ Docker build ล้มเหลว"
  read -p "กด Enter เพื่อปิดหน้าต่าง..."
  exit 1
fi

echo "✅ Docker build สำเร็จ กำลัง push ไป Docker Hub..."
docker push "$IMAGE_NAME"
if [ $? -ne 0 ]; then
  echo "❌ Docker push ล้มเหลว"
  read -p "กด Enter เพื่อปิดหน้าต่าง..."
  exit 1
fi
echo "🚀 Push เสร็จสิ้น: $IMAGE_NAME"

echo "🚀 Docker image พร้อมใช้งาน: $IMAGE_NAME"
read -p "🟢 เสร็จสิ้น กด Enter เพื่อปิดหน้าต่าง..."
