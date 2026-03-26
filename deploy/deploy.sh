#!/bin/bash
# =============================================================
# deploy.sh — Pull latest image & restart Netka Kiosk Web
# Usage:
#   ./deploy.sh              → pull latest + restart
#   ./deploy.sh 1.0.0.xxx    → pull specific tag + restart
# =============================================================

set -e
trap 'echo "❌ Error on line $LINENO"; exit 1' ERR

TAG=${1:-"latest"}
IMAGE="netkaofficialhub/nthaismartweb:$TAG"

echo "🚀 Deploying Netka Kiosk Web: $IMAGE"
echo "📅 $(date '+%Y-%m-%d %H:%M:%S')"
echo ""

# ── ตรวจว่ามีไฟล์ .env แล้ว ──────────────────────────────
if [ ! -f ".env" ]; then
  echo "❌ ไม่พบไฟล์ .env กรุณา copy จาก .env.example แล้วแก้ค่าก่อน"
  exit 1
fi

# ── Pull image ใหม่ ──────────────────────────────────────
echo "⬇️  Pulling image..."
docker pull "$IMAGE"

# ── อัปเดต IMAGE_TAG ใน .env ────────────────────────────
sed -i "s/^IMAGE_TAG=.*/IMAGE_TAG=$TAG/" .env
echo "✅ IMAGE_TAG updated to: $TAG"

# ── Restart web service เท่านั้น (Redis ไม่แตะ) ──────────
echo "🔄 Restarting web service..."
docker compose pull
docker compose up -d --no-deps netka-kiosk-web

echo ""
echo "🟢 Deploy เสร็จสิ้น"
docker compose ps
