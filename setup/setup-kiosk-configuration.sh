#!/usr/bin/env bash
#setup-kiosk-configuration-v6
set -e

echo "🔐 Verifying sudo access..."
sudo -v

# === ตั้งค่าตามต้องการ ===
V_KIOSK_ID="{KIOSK_ID}"
V_KIOSK_CODE="{KIOSK_CODE}"
V_KIOSK_TOKEN="{KIOSK_TOKEN}"
V_URL="{URL}"
V_CARD_READER="1.0.3"

V_Q_STR_1="kiosk_code=${V_KIOSK_CODE}"
V_Q_STR_2="token=${V_KIOSK_TOKEN}"

# === ค่าคงที่ ===
V_SIGNALR_HUB_URL="${V_URL}/NThaiSmartHub"
V_FULL_URL="${V_URL}/Login?${V_Q_STR_1}&${V_Q_STR_2}"
INSTALL_PATH="/opt/ncardreader"
echo "DEBUG: INSTALL_PATH=${INSTALL_PATH}"
sudo mkdir -p "${INSTALL_PATH}"

# ใช้ user kiosk แบบตายตัวเพื่อให้สร้างไฟล์ลง Desktop/Autostart ถูกที่
USERNAME="kiosk"
echo "🧪 USERNAME=$USERNAME"

AUTOSTART_DIR="/home/${USERNAME}/.config/autostart"
DESKTOP_DIR="/home/${USERNAME}/Desktop"
LAUNCHER_PATH="${DESKTOP_DIR}/kiosk.desktop"

sudo mkdir -p "${INSTALL_PATH}"

echo "📝 เขียน docker-compose.yml..."
sudo tee "${INSTALL_PATH}/docker-compose.yml" > /dev/null <<EOF
services:
  ncardreader:
    image: netkaofficialhub/ncardreaderservice:${V_CARD_READER}
    container_name: N-CardReaderService
    privileged: true
    devices:
      - /dev/bus/usb:/dev/bus/usb
    volumes:
      - ./config:/app/config
      - /home/kiosk/Downloads/cmd:/app/cmd
      - /dev:/dev
      - /run/udev:/run/udev
      - /run/pcscd:/run/pcscd
      - /sys:/sys
    environment:
      KIOSK_URL: ${V_URL}
      API_SIGNALR_HUB: /NThaiSmartHub
      KIOSK_ID: ${V_KIOSK_ID}
      KIOSK_CODE: ${V_KIOSK_CODE}
      KIOSK_TOKEN: ${V_KIOSK_TOKEN}
    restart: unless-stopped
    entrypoint: bash -c "pkill pcscd || true && rm -f /run/pcscd/pcscd.comm && pcscd --foreground & sleep 3 && pgrep pcscd && ./N-CardReaderService"
EOF

echo "🚦 เริ่ม docker compose..."
cd "${INSTALL_PATH}" || { echo "Cannot cd to ${INSTALL_PATH}"; exit 1; }
sudo docker compose up -d --pull always
echo "✅ CardReader Service และ Portainer พร้อมใช้งาน"


sudo tee "/usr/local/bin/start-kiosk.sh" > /dev/null <<EOF
#!/bin/bash

export DISPLAY=:0
export XAUTHORITY=/home/kiosk/.Xauthority

google-chrome \
  --password-store=basic \
  --user-data-dir=/home/kiosk/.config/chrome-profile \
  --no-default-browser-check \
  --no-first-run \
  --disable-translate \
  --noerrdialogs \
  --disable-infobars \
  --kiosk "${V_FULL_URL}" \
  --disable-features=TranslateUI \
  --disable-pinch \
  --overscroll-history-navigation=0 \
  --disable-session-crashed-bubble \
  --disable-component-update \
  --disable-background-networking \
  --disable-sync \
  --disable-default-apps \
  --disable-extensions \
  --disable-notifications \
  --disable-background-timer-throttling \
  --disable-client-side-phishing-detection \
  --no-sandbox \
  --disable-popup-blocking \
  --bwsi &
EOF

sudo chmod +x /usr/local/bin/start-kiosk.sh

echo "📌 สร้าง launcher บน Desktop..."
sudo -u "${USERNAME}" mkdir -p "${DESKTOP_DIR}"
cat > "${LAUNCHER_PATH}" <<EOF
[Desktop Entry]
Name=Kiosk Web
Comment=เปิดเว็บ kiosk แบบเต็มจอ
Exec=/usr/local/bin/start-kiosk.sh
Icon=google-chrome
Terminal=false
Type=Application
Categories=Utility;
EOF

chmod +x "${LAUNCHER_PATH}"
chown ${USERNAME}:${USERNAME} "${LAUNCHER_PATH}"
sudo -u "${USERNAME}" gio set "${LAUNCHER_PATH}" metadata::trusted true 2>/dev/null || true

sudo -u "${USERNAME}" mkdir -p "${AUTOSTART_DIR}"
cat > "${AUTOSTART_DIR}/kiosk.desktop" <<EOF
[Desktop Entry]
Name=Kiosk Web Auto
Comment=เปิดเว็บ kiosk แบบเต็มจอเมื่อเปิดเครื่อง
Exec=/usr/local/bin/start-kiosk.sh
Icon=google-chrome
Terminal=false
Type=Application
Categories=Utility;
X-GNOME-Autostart-enabled=true
EOF
chmod +x "${AUTOSTART_DIR}/kiosk.desktop"
chown ${USERNAME}:${USERNAME} "${AUTOSTART_DIR}/kiosk.desktop"

echo "✅ Kiosk launcher พร้อมใช้งาน"

echo "Rebooting in 5 seconds..."
for i in {5..1}; do
    echo "$i..."
    sleep 1
done

sudo mkdir -p /var/lib/kiosk
sudo touch /var/lib/kiosk/reboot-required