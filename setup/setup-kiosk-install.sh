#!/bin/bash
#setup-kiosk-install-v8

set -euo pipefail

USER_NAME="kiosk"
USER_HOME=$(eval echo "~$USER_NAME")
SESSION_NAME="ubuntu"
CONFIG_FILE="/etc/gdm3/custom.conf"

wait_for_apt() {
  echo "⏳ Waiting for apt lock..."
  while sudo fuser /var/lib/dpkg/lock-frontend >/dev/null 2>&1; do
    sleep 2
  done
}

# ---------------------------
# ไม่ต้องสลับ user บน Putty
# ---------------------------
if [ "$(whoami)" != "$USER_NAME" ]; then
    echo "⚠️ You are not $USER_NAME, make sure to run this script as $USER_NAME or with sudo where needed."
fi

echo "🔐 Running as $(whoami)"

echo "📦 Checking and installing curl if needed..."
if ! command -v curl &> /dev/null; then
  echo "📦 Installing curl..."
  wait_for_apt
  sudo apt-get update -y
  wait_for_apt
  sudo apt-get install -y curl
fi

echo "🧹 Removing old Docker packages (if any)..."
wait_for_apt
sudo apt-get remove -y docker docker-engine docker.io containerd runc 2>/dev/null || true

echo "🔄 Updating package index (pre-Docker)..."
wait_for_apt
sudo apt-get update -y

echo "🔧 Installing Docker prerequisites..."
wait_for_apt
sudo apt-get install -y ca-certificates gnupg lsb-release

echo "📁 Creating keyring directory..."
sudo mkdir -p /etc/apt/keyrings

# ดาวน์โหลดและติดตั้ง Docker GPG key (รูปแบบใหม่)
echo "🔑 Adding Docker GPG key..."
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | \
  sudo gpg --dearmor --yes -o /etc/apt/keyrings/docker.gpg

# เปลี่ยน permission ของ key ให้สามารถอ่านได้
sudo chmod a+r /etc/apt/keyrings/docker.gpg

# เพิ่ม Docker repo
echo \
  "deb [arch=$(dpkg --print-architecture) signed-by=/etc/apt/keyrings/docker.gpg] \
  https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | \
  sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# ติดตั้ง Docker จาก repo
echo "🔄 Updating package index (Docker repo)..."
wait_for_apt
sudo apt-get update -y

echo "🐳 Installing Docker engine..."
wait_for_apt
sudo apt-get install -y docker-ce docker-ce-cli containerd.io docker-compose-plugin

# เปิดและเริ่ม Docker
sudo systemctl enable --now docker

# ตรวจสอบเวอร์ชัน
docker --version
docker compose version

# เพิ่ม user ปัจจุบันเข้า docker group (ถ้ายังไม่อยู่)
if ! groups $USER | grep -qw docker; then
  echo "🔧 Adding $USER to docker group..."
  sudo usermod -aG docker $USER
  echo "⚠️ Please logout and login again to apply the docker group changes."
fi

# ✅ Install required packages
echo "🔧 Checking for and installing missing packages..."
NEEDED_PACKAGES=(ca-certificates gnupg lsb-release software-properties-common apt-transport-https dos2unix xinput openssh-server docker-ce docker-ce-cli containerd.io docker-compose-plugin dbus-x11)
MISSING=()

for pkg in "${NEEDED_PACKAGES[@]}"; do
  dpkg -s "$pkg" &> /dev/null || MISSING+=("$pkg")
done

if [ ${#MISSING[@]} -ne 0 ]; then
  echo "📦 Installing missing packages: ${MISSING[*]}"
  wait_for_apt
  sudo apt-get install -y "${MISSING[@]}"
else
  echo "✅ All required packages already installed."
fi

sudo dpkg --configure -a

# -----------------------------
# ✅ Check/install Google Chrome
# -----------------------------
if ! dpkg -s google-chrome-stable &> /dev/null; then
    echo "🌐 Installing Google Chrome..."
    
    # Add Google repo key if not exist
    if [ ! -f /etc/apt/keyrings/google-chrome.gpg ]; then
        wget -q -O - https://dl.google.com/linux/linux_signing_key.pub | \
          sudo gpg --dearmor --yes -o /etc/apt/keyrings/google-chrome.gpg
        sudo chmod a+r /etc/apt/keyrings/google-chrome.gpg
    fi

    # Add Google repo if not exist
    if [ ! -f /etc/apt/sources.list.d/google-chrome.list ]; then
        echo "deb [arch=amd64 signed-by=/etc/apt/keyrings/google-chrome.gpg] http://dl.google.com/linux/chrome/deb/ stable main" | sudo tee /etc/apt/sources.list.d/google-chrome.list
    fi
    
    wait_for_apt
    sudo apt update
    wait_for_apt
    sudo apt install -y google-chrome-stable
else
    echo "✅ Google Chrome is already installed."
fi

echo "🔄 Enabling universe repository if not already enabled..."
if ! grep -r ^deb /etc/apt/sources.list* | grep -q "universe"; then
  wait_for_apt
  sudo add-apt-repository -y universe
  wait_for_apt
  sudo apt-get update -y
else
  echo "✅ Universe repository already enabled."
fi

# 📐 Apply touch coordinate transformation matrix (rotate right matrix)
# 📁 กำหนด path ของสคริปต์และ xprofile
PROP="Coordinate Transformation Matrix"
# ROTATE="left"
# VALUE="0 -1 1 1 0 0 0 0 1"   
ROTATE="right"
VALUE="0 1 0 -1 0 1 0 0 1"  

# กำหนดค่า default ให้ DISPLAY และ XAUTHORITY
: "${DISPLAY:=:0}"
: "${XAUTHORITY:=$USER_HOME/.Xauthority}"

export DISPLAY XAUTHORITY

DEVICE=""
OUTPUT=""

if command -v xinput >/dev/null 2>&1 && command -v xrandr >/dev/null 2>&1 && timeout 2s xrandr >/dev/null 2>&1; then
  DEVICE=$(timeout 2s xinput list --name-only | grep -i 'touch' | head -n 1 || true)
  OUTPUT=$(timeout 2s xrandr | grep " connected" | awk '{print $1}' | head -n 1 || true)

  if [ -n "$OUTPUT" ]; then
    echo "✅ Output: $OUTPUT"
    xrandr --output "$OUTPUT" --rotate "$ROTATE" || true
  else
    echo "⚠️ Display not detected; skipping immediate rotation."
  fi

  if [ -n "$DEVICE" ]; then
    echo "✅ Touch: $DEVICE"
    xinput set-prop "$DEVICE" "$PROP" $VALUE || true
  else
    echo "⚠️ Touchscreen not detected; skipping touch rotation."
  fi
else
  echo "⚠️ No accessible X session; skipping immediate rotation. rotate_touchscreen.sh will retry in-session."
fi

TARGET="$USER_HOME/rotate_touchscreen.sh"
XPROFILE="$USER_HOME/.xprofile"

# 📐 ค่าที่ต้องการตั้ง
echo "📝 สร้างสคริปต์ $TARGET ..."
sudo -u "$USER_NAME" mkdir -p "$USER_HOME"
sudo -u "$USER_NAME" tee "$TARGET" > /dev/null <<EOF
#!/bin/bash
# 📐 ตั้งค่าหมุนทัชสกรีน
DEFAULT_DEVICE="$DEVICE"
DEFAULT_OUTPUT="$OUTPUT"
PROP="$PROP"
VALUE="$VALUE"
ROTATE="$ROTATE"

export DISPLAY=${DISPLAY:-:0}
export XAUTHORITY=${XAUTHORITY:-$USER_HOME/.Xauthority}

if ! command -v xinput >/dev/null 2>&1 || ! command -v xrandr >/dev/null 2>&1; then
  exit 0
fi

if ! timeout 2s xrandr >/dev/null 2>&1; then
  exit 0
fi

while true; do
  DEVICE="\$(timeout 2s xinput list --name-only | grep -i touch | head -n 1 || true)"
  OUTPUT="\$(timeout 2s xrandr | grep ' connected' | awk '{print \$1}' | head -n 1 || true)"

  DEVICE="\${DEVICE:-\${DEFAULT_DEVICE}}"
  OUTPUT="\${OUTPUT:-\${DEFAULT_OUTPUT}}"

  if [ -n "\$OUTPUT" ]; then
    xrandr --output "\$OUTPUT" --rotate "\$ROTATE"
  fi

  if [ -n "\$DEVICE" ]; then
    xinput set-prop "\$DEVICE" "\$PROP" \$VALUE
  fi

  sleep 5
done
EOF

# ✅ ให้สิทธิ์รัน
sudo chmod +x "$TARGET"
sudo -u "$USER_NAME" python3 - <<PY
from pathlib import Path

path = Path("$XPROFILE")
line = "$TARGET &"
lines = []
if path.exists():
    lines = path.read_text().splitlines()
lines = [l for l in lines if l and l != line]
lines.append(line)
path.write_text("\\n".join(lines) + "\\n")
PY
sudo chmod +x "$XPROFILE"

# -------------------------------
# 2. สร้าง systemd user service
# -------------------------------
echo "🧱 create systemd service"

SERVICE_DIR="$USER_HOME/.config/systemd/user"
SERVICE_FILE="$SERVICE_DIR/rotate-touch.service"
USER_ID=$(id -u "$USER_NAME")
USER_RUNTIME_DIR="/run/user/$USER_ID"

sudo mkdir -p "$SERVICE_DIR"
sudo chown -R "$USER_NAME:$USER_NAME" "$USER_HOME/.config/systemd"

echo "SERVICE_DIR=$SERVICE_DIR"
echo "SERVICE_FILE=$SERVICE_FILE"

sudo -u "$USER_NAME" tee "$SERVICE_FILE" > /dev/null <<EOF
[Unit]
Description=Rotate Touchscreen and Display
After=graphical-session.target

[Service]
Type=simple
ExecStart=/home/kiosk/rotate_touchscreen.sh
Restart=always
RestartSec=2
Environment=DISPLAY=:0
Environment=XAUTHORITY=/home/kiosk/.Xauthority

[Install]
WantedBy=default.target
EOF

# -------------------------------
# 3. enable linger (needed before using systemctl --user outside a session)
# -------------------------------
echo "🔓 enable linger"
loginctl enable-linger "$USER_NAME"

# Ensure runtime dir exists/owned for user systemd
sudo mkdir -p "$USER_RUNTIME_DIR"
sudo chown "$USER_NAME:$USER_NAME" "$USER_RUNTIME_DIR"

# -------------------------------
# 4. enable + start service
# -------------------------------
echo "🚀 enable service"

sudo -u "$USER_NAME" XDG_RUNTIME_DIR="$USER_RUNTIME_DIR" DBUS_SESSION_BUS_ADDRESS="unix:path=$USER_RUNTIME_DIR/bus" systemctl --user daemon-reexec || true
sudo -u "$USER_NAME" XDG_RUNTIME_DIR="$USER_RUNTIME_DIR" DBUS_SESSION_BUS_ADDRESS="unix:path=$USER_RUNTIME_DIR/bus" systemctl --user daemon-reload
sudo -u "$USER_NAME" XDG_RUNTIME_DIR="$USER_RUNTIME_DIR" DBUS_SESSION_BUS_ADDRESS="unix:path=$USER_RUNTIME_DIR/bus" systemctl --user enable rotate-touch.service
sudo -u "$USER_NAME" XDG_RUNTIME_DIR="$USER_RUNTIME_DIR" DBUS_SESSION_BUS_ADDRESS="unix:path=$USER_RUNTIME_DIR/bus" systemctl --user restart rotate-touch.service

# 🛠️ GRUB config
if ! grep -q '^GRUB_TIMEOUT=5' /etc/default/grub; then
    echo "🛠️ Updating GRUB to boot Ubuntu by default with 5s timeout..."
    sudo cp /etc/default/grub /etc/default/grub.bak
    sudo sed -i 's/^GRUB_DEFAULT=.*/GRUB_DEFAULT=0/' /etc/default/grub
    sudo sed -i 's/^GRUB_TIMEOUT=.*/GRUB_TIMEOUT=5/' /etc/default/grub
    if ! grep -q "^GRUB_TIMEOUT_STYLE=" /etc/default/grub; then
        echo 'GRUB_TIMEOUT_STYLE=menu' | sudo tee -a /etc/default/grub
    fi
    sudo update-grub
else
    echo "✅ GRUB already configured."
fi

echo "🌐 Adding Thai keyboard layout..."
# ตรวจสอบว่าติดตั้ง sudo -u $USER_NAME dbus-launch gsettings แล้ว
if ! command -v gsettings &>/dev/null; then
    echo "❌ gsettings not found. Please run this script in a desktop session with GNOME."
fi

# เพิ่ม layout ภาษาไทย (th) ต่อจาก us
LAYOUTS=$(sudo -u $USER_NAME dbus-launch gsettings get org.gnome.desktop.input-sources sources)
if [[ "$LAYOUTS" != *"('xkb', 'th')"* ]]; then
    echo "📝 Adding Thai layout to input sources..."
    sudo -u $USER_NAME dbus-launch gsettings set org.gnome.desktop.input-sources sources "[('xkb', 'us'), ('xkb', 'th')]"
else
    echo "✅ Thai layout already added."
fi

# ตั้งค่าปุ่มสลับภาษาเป็น Alt+Shift
echo "🎛️ Setting Alt+Shift as layout switch shortcut..."
sudo -u $USER_NAME dbus-launch gsettings set org.gnome.desktop.wm.keybindings switch-input-source "['<Alt>Shift_L']"
sudo -u $USER_NAME dbus-launch gsettings set org.gnome.desktop.wm.keybindings switch-input-source-backward "['<Shift>Alt_L']"

# ปิดการใช้งาน Caps Lock เปลี่ยนภาษา (ถ้าเคยตั้ง)
sudo -u $USER_NAME dbus-launch gsettings set org.gnome.desktop.input-sources xkb-options "['grp:alt_shift_toggle']"
echo "✅ Thai keyboard layout configured."

# 🛑 Disable screensaver/lock
echo "🛑 Disabling screen blanking and lock..."
sudo -u $USER_NAME dbus-launch gsettings set org.gnome.desktop.session idle-delay 0
sudo -u $USER_NAME dbus-launch gsettings set org.gnome.desktop.screensaver lock-enabled false
sudo -u $USER_NAME dbus-launch gsettings set org.gnome.desktop.screensaver idle-activation-enabled false
sudo -u $USER_NAME dbus-launch gsettings set org.gnome.settings-daemon.plugins.power idle-dim false
sudo -u $USER_NAME dbus-launch gsettings set org.gnome.settings-daemon.plugins.power sleep-inactive-ac-timeout 0
sudo -u $USER_NAME dbus-launch gsettings set org.gnome.settings-daemon.plugins.power sleep-inactive-ac-type 'nothing'
sudo -u $USER_NAME dbus-launch gsettings set org.gnome.settings-daemon.plugins.power sleep-inactive-battery-timeout 0
sudo -u $USER_NAME dbus-launch gsettings set org.gnome.settings-daemon.plugins.power sleep-inactive-battery-type 'nothing'
echo "✅ Screen blanking and lock disabled."

CONFIG_FILE="/etc/gdm3/custom.conf"

echo "User detected: $USER_NAME"
echo "Configuring autologin + disable Wayland in $CONFIG_FILE"

sudo cp "$CONFIG_FILE" "${CONFIG_FILE}.bak.$(date +%F_%T)"

# normalize GDM config: ensure settings live under [daemon]
sudo python3 - <<PY
from pathlib import Path

path = Path("$CONFIG_FILE")
lines = path.read_text().splitlines()

# drop existing settings anywhere
filtered = [
    l for l in lines
    if not l.strip().startswith(("AutomaticLoginEnable=", "AutomaticLogin=", "WaylandEnable="))
]

try:
    idx = next(i for i, l in enumerate(filtered) if l.strip() == "[daemon]")
except StopIteration:
    idx = 0
    filtered.insert(0, "[daemon]")

insert = [
    "WaylandEnable=false",
    "AutomaticLoginEnable=true",
    "AutomaticLogin=$USER_NAME",
]
filtered[idx + 1:idx + 1] = insert
path.write_text("\\n".join(filtered) + "\\n")
PY

echo "✅ Disabled Wayland in GDM."

# 📁 ค้นหา session xorg ที่ใช้งานได้
SESSION_NAME="ubuntu"
if [ -f "/usr/share/xsessions/ubuntu-xorg.desktop" ]; then
    SESSION_NAME="ubuntu-xorg"
fi

# 👤 สร้างหรืออัปเดต ~/.dmrc
USER_HOME=$(eval echo "~$USER_NAME")
cat <<EOF | sudo tee "$USER_HOME/.dmrc"
[Desktop]
Session=$SESSION_NAME
EOF

sudo chmod 644 "$USER_HOME/.dmrc"
sudo chown $USER_NAME:$USER_NAME "$USER_HOME/.dmrc"

echo "✅ Default session set to: $SESSION_NAME"


# ────────────────────────────────
# 8️⃣ UFW (ปลอดภัยแต่ใช้งานได้)
# ────────────────────────────────
echo "🔐 Enabling SSH service..."
sudo systemctl enable ssh
sudo systemctl start ssh

sudo ufw allow 22
sudo ufw allow 80
sudo ufw allow 443
sudo ufw --force enable


# ─────────────────────────────────────────────
# Remove legacy kiosk-command-runner (deprecated)
# ─────────────────────────────────────────────
if systemctl list-unit-files | grep -q "^kiosk-command-runner.service"; then
  echo "🧹 Removing legacy kiosk-command-runner service..."
  sudo systemctl stop kiosk-command-runner 2>/dev/null || true
  sudo systemctl disable kiosk-command-runner 2>/dev/null || true
  sudo rm -f /etc/systemd/system/kiosk-command-runner.service
  sudo rm -f /usr/local/bin/kiosk-command-runner
  sudo systemctl daemon-reload
else
  echo "✅ Legacy kiosk-command-runner not found."
fi


# --------------------------------------------
#
# Kiosk configuration listener (auto-run kiosk-configuration.sh)
#
# --------------------------------------------
SERVICE_NAME="kiosk-configuration-listener"
BIN_PATH="/usr/local/bin/kiosk-configuration-listener"
SERVICE_PATH="/etc/systemd/system/${SERVICE_NAME}.service"

echo "🚀 Installing ${SERVICE_NAME} ..."

echo "📝 Writing $BIN_PATH"
sudo tee "$BIN_PATH" > /dev/null <<'EOF'
#!/bin/bash
set -euo pipefail

CONFIG_PATH="/home/kiosk/Downloads/kiosk-configuration.sh"
DONE_DIR="/home/kiosk/Downloads"
LOG="/var/log/kiosk-configuration-listener.log"
SLEEP=5
NOTIFY_USER="kiosk"
NOTIFY_INTERVAL=5

mkdir -p "$DONE_DIR"
mkdir -p "$(dirname "$LOG")"

exec >> "$LOG" 2>&1

echo "[INFO] kiosk-configuration-listener started at $(date)"

notify_user() {
  local title="${1:-Kiosk Configuration}"
  local message="${2:-กำลังอัพเดตเครื่อง กรุณารอสักครู่}"
  local replace_id="${3:-}"
  local timeout="${4:-5000}"
  if ! command -v notify-send >/dev/null 2>&1; then
    return 0
  fi
  if ! id "$NOTIFY_USER" >/dev/null 2>&1; then
    return 0
  fi
  uid="$(id -u "$NOTIFY_USER")"
  bus="/run/user/$uid/bus"
  if [ ! -S "$bus" ]; then
    return 0
  fi
  sudo -u "$NOTIFY_USER" DBUS_SESSION_BUS_ADDRESS="unix:path=$bus" DISPLAY=:0 \
    notify-send -u normal -t "$timeout" ${replace_id:+-r "$replace_id"} -p "$title" "$message" 2>/dev/null || true
}

format_elapsed() {
  local secs="$1"
  printf "%02d:%02d" $((secs / 60)) $((secs % 60))
}

start_progress() {
  local title="$1"
  local start_ts="$2"
  local notify_id="$3"

  [ -n "$notify_id" ] || return 0

  (
    last_msg=""
    while true; do
      sleep "$NOTIFY_INTERVAL"

      local msg now elapsed pct

      if [ -f "$PROGRESS_FILE" ]; then
        pct="$(cat "$PROGRESS_FILE" 2>/dev/null || true)"
        if [[ "$pct" =~ ^[0-9]{1,3}$ ]] && [ "$pct" -le 100 ]; then
          msg="กำลังอัพเดต... ${pct}%"
        fi
      fi

      # fallback เป็นเวลา
      if [ -z "${msg:-}" ]; then
        now=$(date +%s)
        elapsed=$((now - start_ts))
        msg="กำลังทำงาน... ใช้เวลา $(format_elapsed "$elapsed")"
      fi

      # update เฉพาะตอนข้อความเปลี่ยน (ลด spam)
      if [ "$msg" != "$last_msg" ]; then
        notify_user "$title" "$msg" "$notify_id" 0 >/dev/null || true
        last_msg="$msg"
      fi
    done
  ) &
  echo $!
}


stop_progress() {
  local pid="$1"
  [ -n "$pid" ] || return 0
  kill "$pid" 2>/dev/null || true
  wait "$pid" 2>/dev/null || true
}

while true; do
  if [ -f "$CONFIG_PATH" ]; then
    ts="$(date +%F_%H%M%S)"
    done_path="$DONE_DIR/kiosk-configuration.${ts}.done"
    echo "[INFO] Found $CONFIG_PATH"
    mv "$CONFIG_PATH" "$done_path"
    echo "[INFO] Moved to $done_path"
    notify_id="990101"
    notify_user "Kiosk Configuration" "เริ่มอัพเดต Configuration" "$notify_id" 0 >/dev/null || true
    start_ts=$(date +%s)
    progress_pid=$(start_progress "Kiosk Configuration" "$start_ts" "$notify_id")
    chmod +x "$done_path" || true
    if bash "$done_path"; then
      echo "[INFO] OK"
      stop_progress "$progress_pid"
      notify_user "Kiosk Configuration" "อัพเดต Configuration เสร็จแล้ว" "$notify_id" 5000 >/dev/null || true
    else
      rc=$?
      echo "[ERROR] Failed rc=$rc"
      stop_progress "$progress_pid"
      notify_user "Kiosk Configuration" "อัพเดต Configuration ล้มเหลว" "$notify_id" 5000 >/dev/null || true
    fi
  fi
  sleep "$SLEEP"
done
EOF

sudo chmod +x "$BIN_PATH"
sudo chown root:root "$BIN_PATH"

echo "🧱 Writing systemd service $SERVICE_PATH"
sudo tee "$SERVICE_PATH" > /dev/null <<EOF
[Unit]
Description=Kiosk Configuration Listener
After=network-online.target
Wants=network-online.target

[Service]
Type=simple
ExecStart=$BIN_PATH
Restart=always
RestartSec=3
User=root
Group=root
Environment=PATH=/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin
StandardOutput=journal
StandardError=journal

[Install]
WantedBy=multi-user.target
EOF

echo "🔄 Reloading systemd"
sudo systemctl daemon-reexec
sudo systemctl daemon-reload

echo "✅ Enabling service"
sudo systemctl enable "$SERVICE_NAME"

echo "▶️ Starting service"
sudo systemctl restart "$SERVICE_NAME"

echo "📊 Service status:"
sudo systemctl status "$SERVICE_NAME" --no-pager

# --------------------------------------------
#
# Kiosk command listener (JSON commands)
#
# --------------------------------------------
SERVICE_NAME="kiosk-command-listener"
BIN_PATH="/usr/local/bin/kiosk-command-listener"
SERVICE_PATH="/etc/systemd/system/${SERVICE_NAME}.service"

echo "🚀 Installing ${SERVICE_NAME} ..."

echo "📝 Writing $BIN_PATH"
sudo tee "$BIN_PATH" > /dev/null <<'EOF'
#!/bin/bash
set -euo pipefail

CMD_DIR="/home/kiosk/Downloads/cmd"
DONE_DIR="$CMD_DIR/done"
ERR_DIR="$CMD_DIR/error"
STATE_DIR="$CMD_DIR/.state"

LOG="/var/log/kiosk-command-listener.log"
SLEEP=2
NOTIFY_USER="kiosk"
NOTIFY_INTERVAL=5
CMD_TIMEOUT="10m"

mkdir -p "$CMD_DIR" "$DONE_DIR" "$ERR_DIR" "$STATE_DIR"
mkdir -p "$(dirname "$LOG")"

exec >> "$LOG" 2>&1

echo "[INFO] kiosk-command-listener started at $(date)"

notify_user() {
  local title="${1:-Kiosk Update}"
  local message="${2:-กำลังอัพเดตเครื่อง กรุณารอสักครู่}"
  local replace_id="${3:-}"
  local timeout="${4:-5000}"

  command -v notify-send >/dev/null 2>&1 || return 0
  id "$NOTIFY_USER" >/dev/null 2>&1 || return 0

  uid="$(id -u "$NOTIFY_USER")"
  bus="/run/user/$uid/bus"
  [ -S "$bus" ] || return 0

  sudo -u "$NOTIFY_USER" \
    DBUS_SESSION_BUS_ADDRESS="unix:path=$bus" DISPLAY=:0 \
    notify-send -u normal -t "$timeout" \
    ${replace_id:+-r "$replace_id"} -p "$title" "$message" 2>/dev/null || true
}

format_elapsed() {
  local secs="$1"
  printf "%02d:%02d" $((secs / 60)) $((secs % 60))
}

start_progress() {
  local title="$1"
  local start_ts="$2"
  local notify_id="$3"
  [ -n "$notify_id" ] || return 0

  (
    while true; do
      sleep "$NOTIFY_INTERVAL"
      local now elapsed
      now=$(date +%s)
      elapsed=$((now - start_ts))
      notify_user "$title" \
        "กำลังทำงาน... ใช้เวลา $(format_elapsed "$elapsed")" \
        "$notify_id" 0 >/dev/null || true
    done
  ) &
  echo $!
}

stop_progress() {
  local pid="$1"
  [ -n "$pid" ] || return 0
  kill "$pid" 2>/dev/null || true
  wait "$pid" 2>/dev/null || true
}

# -------------------------------------------------
# Extract commands from JSON
# -------------------------------------------------
extract_cmds() {
  python3 - "$1" <<'PY'
import json, sys

path = sys.argv[1]
try:
    with open(path, "r", encoding="utf-8") as f:
        data = json.load(f)
except Exception:
    sys.exit(1)

cmds = []

def add_cmd(item):
    if not isinstance(item, dict):
        return
    if item.get("is_enabled", 1) not in (1, True, "1"):
        return
    cmd = item.get("command_text")
    if not cmd:
        return
    if item.get("allow_args") in (1, True, "1"):
        args = item.get("args") or item.get("command_args")
        if isinstance(args, list):
            cmd += " " + " ".join(str(x) for x in args)
        elif isinstance(args, str) and args.strip():
            cmd += " " + args
    cmds.append(cmd)

if isinstance(data, dict):
    if "command_text" in data:
        add_cmd(data)
    elif isinstance(data.get("kiosk_control_command"), list):
        for it in data["kiosk_control_command"]:
            add_cmd(it)
    elif isinstance(data.get("commands"), list):
        for it in data["commands"]:
            add_cmd(it)
elif isinstance(data, list):
    for it in data:
        add_cmd(it)

for c in cmds:
    print(c)
PY
}

# -------------------------------------------------
# Main loop
# -------------------------------------------------
while true; do
  shopt -s nullglob
  files=("$CMD_DIR"/*.json "$CMD_DIR"/*.cmd "$CMD_DIR"/*.txt)
  shopt -u nullglob

  for file in "${files[@]}"; do
    [ -f "$file" ] || continue

    fname="$(basename "$file")"
    hash="$(sha256sum "$file" | awk '{print $1}')"
    state_file="$STATE_DIR/$fname.sha256"

    # ถ้า content เดิม → ข้าม
    if [ -f "$state_file" ] && grep -q "$hash" "$state_file"; then
      continue
    fi

    echo "[INFO] Processing $file"

    if ! cmds="$(extract_cmds "$file")"; then
      echo "[ERROR] Parse failed: $file"
      mv "$file" "$ERR_DIR/$fname.bad"
      continue
    fi

    if [ -z "$cmds" ]; then
      echo "[WARN] No commands found: $file"
      mv "$file" "$ERR_DIR/$fname.empty"
      continue
    fi

    # เก็บ history (ไม่กระทบการอ่านซ้ำ)
    cp "$file" "$DONE_DIR/$fname.$(date +%F_%H%M%S).done"

    notify_id="990102"
    notify_user "Kiosk Command" "เริ่มทำ Command จาก Server" "$notify_id" 0 >/dev/null || true
    start_ts=$(date +%s)
    progress_pid=$(start_progress "Kiosk Command" "$start_ts" "$notify_id")

    while IFS= read -r cmd; do
      [ -n "$cmd" ] || continue
      echo "[INFO] Run: $cmd"

      if timeout "$CMD_TIMEOUT" bash -c "$cmd"; then
        echo "[INFO] OK"
      else
        rc=$?
        if [ "$rc" -eq 124 ]; then
          echo "[ERROR] Timeout after $CMD_TIMEOUT: $cmd"
        else
          echo "[ERROR] Failed rc=$rc: $cmd"
        fi
      fi
    done <<< "$cmds"

    stop_progress "$progress_pid"
    notify_user "Kiosk Command" "Command จาก Server เสร็จแล้ว" "$notify_id" 5000 >/dev/null || true

    # บันทึก hash หลังทำสำเร็จ
    echo "$hash" > "$state_file"
  done

  sleep "$SLEEP"
done
EOF

sudo chmod +x "$BIN_PATH"
sudo chown root:root "$BIN_PATH"

echo "🧱 Writing systemd service $SERVICE_PATH"
sudo tee "$SERVICE_PATH" > /dev/null <<EOF
[Unit]
Description=Kiosk Command Listener
After=network-online.target
Wants=network-online.target

[Service]
Type=simple
ExecStart=$BIN_PATH
Restart=always
RestartSec=3

User=root
Group=root

# ให้ systemd คุม child process ทั้งหมด
KillMode=control-group

# ไม่ให้ fork มั่ว
TimeoutStopSec=5

Environment=PATH=/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin
StandardOutput=journal
StandardError=journal

[Install]
WantedBy=multi-user.target
EOF

echo "🔄 Reloading systemd"
sudo systemctl daemon-reexec
sudo systemctl daemon-reload

echo "✅ Enabling service"
sudo systemctl enable "$SERVICE_NAME"

echo "▶️ Starting service"
sudo systemctl restart "$SERVICE_NAME"

echo "📊 Service status:"
sudo systemctl status "$SERVICE_NAME" --no-pager

# --------------------------------------------
#
# Kiosk install listener (auto-run /kiosk-install.sh)
#
# --------------------------------------------
SERVICE_NAME="kiosk-install-listener"
BIN_PATH="/usr/local/bin/kiosk-install-listener"
SERVICE_PATH="/etc/systemd/system/${SERVICE_NAME}.service"

echo "🚀 Installing ${SERVICE_NAME} ..."

echo "📝 Writing $BIN_PATH"
sudo tee "$BIN_PATH" > /dev/null <<'EOF'
#!/bin/bash
set -euo pipefail

# -------------------------------------------------
# Paths & runtime
# -------------------------------------------------
INSTALL_PATH="/home/kiosk/Downloads/kiosk-install.sh"
DONE_DIR="/home/kiosk/Downloads"
STATE_FILE="/var/lib/kiosk-install-listener.last_mtime"
LOG="/var/log/kiosk-install-listener.log"
SLEEP=5

# -------------------------------------------------
# Notification config
# -------------------------------------------------
NOTIFY_USER="kiosk"
NOTIFY_INTERVAL=5
NOTIFY_TITLE="Kiosk Install"

MSG_START="เริ่มอัพเดต Install"
MSG_PROGRESS_PREFIX="กำลังทำงาน... ใช้เวลา"
MSG_SUCCESS="อัพเดต Install เสร็จแล้ว"
MSG_FAILED="อัพเดต Install ล้มเหลว"

# -------------------------------------------------
# Init
# -------------------------------------------------
mkdir -p "$DONE_DIR"
mkdir -p "$(dirname "$LOG")"
mkdir -p "$(dirname "$STATE_FILE")"

touch "$STATE_FILE"
exec >> "$LOG" 2>&1

echo "[INFO] ${NOTIFY_TITLE} listener started at $(date)"

# -------------------------------------------------
# Notification helpers
# -------------------------------------------------
notify_user() {
  local title="$1"
  local message="$2"
  local replace_id="${3:-}"
  local timeout="${4:-5000}"

  command -v notify-send >/dev/null 2>&1 || return 0
  id "$NOTIFY_USER" >/dev/null 2>&1 || return 0

  local uid bus nid
  uid="$(id -u "$NOTIFY_USER")"
  bus="/run/user/$uid/bus"
  [ -S "$bus" ] || return 0

  nid=$(sudo -u "$NOTIFY_USER" \
    DBUS_SESSION_BUS_ADDRESS="unix:path=$bus" DISPLAY=:0 \
    notify-send -u normal -t "$timeout" \
    ${replace_id:+-r "$replace_id"} -p \
    "$title" "$message" 2>/dev/null || true)

  echo "$nid"
}

format_elapsed() {
  local secs="$1"
  printf "%02d:%02d" $((secs / 60)) $((secs % 60))
}

start_progress() {
  local start_ts="$1"
  local notify_id="$2"

  (
    while true; do
      sleep "$NOTIFY_INTERVAL"
      local elapsed=$(( $(date +%s) - start_ts ))
      notify_user \
        "$NOTIFY_TITLE" \
        "$MSG_PROGRESS_PREFIX $(format_elapsed "$elapsed")" \
        "$notify_id" 0 >/dev/null || true
    done
  ) &
  echo $!
}

stop_progress() {
  local pid="$1"
  [ -n "$pid" ] || return 0
  kill "$pid" 2>/dev/null || true
  wait "$pid" 2>/dev/null || true
}

# -------------------------------------------------
# Main loop (file-exists based)
# -------------------------------------------------
while true; do
  if [ -f "$INSTALL_PATH" ]; then
    ts="$(date +%F_%H%M%S)"
    done_path="$DONE_DIR/kiosk-install.${ts}.done"

    echo "[INFO] Found install script, processing..."

    mv "$INSTALL_PATH" "$done_path"
    chmod +x "$done_path" || true

    notify_id="990103"
    notify_user "$NOTIFY_TITLE" "$MSG_START" "$notify_id" 0 >/dev/null || true
    start_ts=$(date +%s)
    progress_pid=$(start_progress "$start_ts" "$notify_id")

    if bash "$done_path"; then
      echo "[INFO] Install OK"
      stop_progress "$progress_pid"
      notify_user "$NOTIFY_TITLE" "$MSG_SUCCESS" "$notify_id" 3000
    else
      rc=$?
      echo "[ERROR] Install failed rc=$rc"
      stop_progress "$progress_pid"
      notify_user "$NOTIFY_TITLE" "$MSG_FAILED" "$notify_id" 5000
    fi
  fi

  sleep "$SLEEP"
done
EOF

sudo chmod +x "$BIN_PATH"
sudo chown root:root "$BIN_PATH"

echo "🧱 Writing systemd service $SERVICE_PATH"
sudo tee "$SERVICE_PATH" > /dev/null <<EOF
[Unit]
Description=Kiosk Install Listener
After=network-online.target
Wants=network-online.target

[Service]
Type=simple
ExecStart=$BIN_PATH
Restart=always
RestartSec=3
User=root
Group=root
KillMode=control-group
TimeoutStopSec=10
Environment=PATH=/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin
StandardOutput=journal
StandardError=journal

[Install]
WantedBy=multi-user.target
EOF

echo "🔄 Reloading systemd"
sudo systemctl daemon-reexec
sudo systemctl daemon-reload

echo "✅ Enabling service"
sudo systemctl enable "$SERVICE_NAME"

echo "▶️ Starting service"
sudo systemctl restart "$SERVICE_NAME"

echo "📊 Service status:"
sudo systemctl status "$SERVICE_NAME" --no-pager


# --------------------------------------------
# Install kiosk reboot watcher (safe reboot)
# --------------------------------------------
echo "🔁 Installing kiosk reboot watcher..."

sudo tee /usr/local/bin/kiosk-reboot-watcher > /dev/null <<'EOF'
#!/bin/bash
set -e

FLAG="/var/lib/kiosk/reboot-required"
LOG="/var/log/kiosk-reboot-watcher.log"

mkdir -p /var/lib/kiosk
touch "$LOG"
exec >> "$LOG" 2>&1

echo "[INFO] Kiosk reboot watcher started"

while true; do
  if [ -f "$FLAG" ]; then
    echo "[INFO] Reboot flag detected"
    rm -f "$FLAG"
    sleep 2
    systemctl reboot
  fi
  sleep 2
done
EOF

sudo chmod +x /usr/local/bin/kiosk-reboot-watcher

WATCHER_SERVICE="/etc/systemd/system/kiosk-reboot-watcher.service"
sudo tee "$WATCHER_SERVICE" > /dev/null <<'EOF'
[Unit]
Description=Kiosk Reboot Watcher
After=multi-user.target

[Service]
Type=simple
ExecStart=/usr/local/bin/kiosk-reboot-watcher
Restart=always
RestartSec=3
User=root
Group=root

[Install]
WantedBy=multi-user.target
EOF

sudo chmod 644 "$WATCHER_SERVICE"

sudo systemctl daemon-reload

echo "▶️ Starting kiosk-reboot-watcher"
sudo systemctl start kiosk-reboot-watcher.service

echo "✅ Enabling kiosk-reboot-watcher"
sudo systemctl enable kiosk-reboot-watcher.service

sudo systemctl status kiosk-reboot-watcher --no-pager

# --------------------------------------------
# Chrome shortcut (manual only)
# ใช้ KIOSK_URL จาก env ถ้ามี ถ้าไม่มีจะลองอ่านจากสคริปต์ config ใน Downloads
# --------------------------------------------
echo "🌐 Creating Chrome shortcut (manual only)..."
TARGET_USER="${SUDO_USER:-$USER_NAME}"
TARGET_HOME=$(eval echo "~$TARGET_USER")
DESKTOP_DIR="$TARGET_HOME/Desktop"
CHROME_SHORTCUT="$DESKTOP_DIR/Kiosk Register.desktop"
CONFIG_SCRIPT="$TARGET_HOME/Downloads/kiosk-configuration.sh"
KIOSK_URL="${KIOSK_URL:-}"
DEFAULT_KIOSK_URL="https://kiosk.netkasystem.co.th"

if [ -z "$KIOSK_URL" ] && [ -f "$CONFIG_SCRIPT" ]; then
  KIOSK_URL=$(grep -E '^V_URL=' "$CONFIG_SCRIPT" | head -n 1 | cut -d'=' -f2- | tr -d '"')
fi

if [ -z "$KIOSK_URL" ]; then
  KIOSK_URL="$DEFAULT_KIOSK_URL"
fi

if [ -z "$KIOSK_URL" ]; then
  echo "⚠️ KIOSK_URL not provided and $CONFIG_SCRIPT not found; skipping manual Chrome shortcut."
else
  sudo -u "$TARGET_USER" mkdir -p "$DESKTOP_DIR"
  sudo -u "$TARGET_USER" tee "$CHROME_SHORTCUT" > /dev/null <<EOF
[Desktop Entry]
Name=Kiosk Register
Comment=เปิดเว็บ kiosk ด้วย Google Chrome
Exec=google-chrome --password-store=basic --user-data-dir=/home/${TARGET_USER}/.config/chrome-profile --new-window "${KIOSK_URL}"
Icon=google-chrome
Terminal=false
Type=Application
Categories=Network;WebBrowser;
EOF
  sudo chmod +x "$CHROME_SHORTCUT"
  sudo chown "$TARGET_USER:$TARGET_USER" "$CHROME_SHORTCUT"
  sudo -u "$TARGET_USER" gio set "$CHROME_SHORTCUT" metadata::trusted true 2>/dev/null || true
  echo "✅ Chrome shortcut created at $CHROME_SHORTCUT"
fi

echo "🎉 Installation completed successfully"

# --------------------------------------------
# Disable GNOME Keyring to prevent prompts
# --------------------------------------------
echo "🔒 Disabling GNOME Keyring..."
sudo rm -rf /home/"$USER_NAME"/.local/share/keyrings
sudo mkdir -p /etc/xdg/autostart/disabled
sudo mv /etc/xdg/autostart/gnome-keyring-*.desktop /etc/xdg/autostart/disabled/ 2>/dev/null || true
sudo systemctl --global disable gnome-keyring-daemon.service 2>/dev/null || true
sudo systemctl --global disable gnome-keyring-daemon.socket 2>/dev/null || true
sudo systemctl --global mask gnome-keyring-daemon.service 2>/dev/null || true
sudo systemctl --global mask gnome-keyring-daemon.socket 2>/dev/null || true
sudo systemctl --global mask gnome-keyring-daemon.target 2>/dev/null || true
sudo systemctl --global mask gnome-keyring-daemon-ssh.socket 2>/dev/null || true
sudo systemctl --global mask gnome-keyring-daemon-secrets.socket 2>/dev/null || true
sudo systemctl --global mask gnome-keyring-daemon-pkcs11.socket 2>/dev/null || true
for f in /etc/pam.d/*; do
  if grep -q "pam_gnome_keyring.so" "$f"; then
    sudo sed -i 's/^.*pam_gnome_keyring.so/# &/' "$f"
  fi
done
echo "✅ GNOME Keyring disabled."

# เคลียร์แพ็กเกจที่ไม่ใช้แล้ว (dependencies หลุด)
wait_for_apt
sudo apt-get autoremove -y

echo "✅ Setup complete."
echo "🧾 Your IP Address: $(hostname -I | awk '{print $1}')"

echo "Rebooting in 5 seconds..."
for i in {5..1}; do
    echo "$i..."
    sleep 1
done

echo "[INFO] Request reboot"
sudo mkdir -p /var/lib/kiosk
sudo touch /var/lib/kiosk/reboot-required
