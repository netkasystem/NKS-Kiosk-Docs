const connection = new signalR.HubConnectionBuilder().withUrl("/NThaiSmartHub").withAutomaticReconnect().build();
connection.start().then(() => {
    console.log("✅ Web Connected");
    // ขอข้อมูล kiosk
    connection.invoke("RequestKioskList");

    setInterval(() => {
        if (connection.state === signalR.HubConnectionState.Connected) {
            connection.invoke("RequestKioskList");
        }
    }, 2 * 60 * 1000);

    const KioskCode = window.GetKioskCode();
    if (KioskCode) selectKiosk(KioskCode);
}).catch(err => console.error("❌ SignalR error: ", err));

connection.onreconnected(() => {
    console.log("🔁 Reconnected");
    // ขอข้อมูล kiosk
    connection.invoke("RequestKioskList");
});

// รับสถานะเครื่องอ่าน
connection.on("KioskStatus", (data) => {
    // 🎯 อัปเดตเครื่องที่เลือกอยู่ (ถ้ามี)
    console.log(`[${data.timestamp}] ${data.statusCode}: ${data.statusText}`);
    console.log(`[${data.timestamp}] ${data.statusCode}: ${data.statusText}`);

    if (data.statusCode === "card_error") {
        next_page("/Step/Step6", 3);
    }
    if (data.statusCode === "card_detected") {
    }
    if (data.statusCode === "card_removed") {
        window.withoutCard();
    }
});

// รับข้อมูลบัตร
connection.on("KioskMessage", (data) => { showCardInfo(data); });
function showCardInfo(data) {
    setCardData(data);
    onCardInserted();
}

// ฟังก์ชันเคลียร์ข้อมูลบัตร
function clearCardInfo() {
    removeCardData();
}

// รับรายการ kiosk ทั้งหมดที่เชื่อมอยู่
connection.on("KioskList", (data) => { renderKioskList(data); });
function renderKioskList(kioskArray) {
    const kioskList = document.getElementById("kiosk-list");
    kioskList.innerHTML = "";

    // เรียงให้ Connected อยู่ข้างบน
    kioskArray.sort((a, b) => b.connected - a.connected);

    kioskArray.forEach(kiosk => {
        const btn = document.createElement("button");
        btn.className = "list-group-item list-group-item-action d-flex justify-content-between align-items-center";

        // กำหนดสถานะเชื่อมต่อ
        let connectionStatus = `<small class="text-success">🟢</small>`;
        if (!kiosk.connected) {
            connectionStatus = `<small class="text-danger">🔴</small>`;
            btn.classList.add("border-danger");
        }

        btn.innerHTML = `<div class="w-100">
                             <div class="d-flex justify-content-between align-items-center">
                                 <span>🖥️ ${connectionStatus} ${kiosk.kioskCode}</span>
                                 <small class="text-body-secondary text-end" style="font-size: 0.75rem;">${timeAgo(kiosk.lastUpdateTime)}</small>
                             </div>
                         </div>`;

        btn.onclick = () => selectKiosk(kiosk.kioskCode);
        kioskList.appendChild(btn);
    });
}

// รับข้อมูลบัตร
connection.on("KioskControlPage", (data) => { showCardInfo(data); });
function ControlPage(data) {
    console.log(`call ControlPage ${data}`);
}

// เรียกใช้เมื่อคลิก "เลือกตู้"
function selectKiosk(id) {
    const kioskNo = document.getElementById("kiosk-no");
    if (kioskNo) kioskNo.innerText = `📡 เชื่อมต่อกับตู้: ${id}`;

    const kioskElements = document.querySelectorAll(".connected-kiosk");
    if (kioskElements) {
        kioskElements.forEach(el => {
            el.textContent = "❌ ไม่ได้เชื่อมต่อกับตู้";
            if (id) el.textContent = `✅ ตู้: ${id}`;
        });
    }

    SetKioskCode(id);
    //สมัครเข้ารับข้อมูลของ kiosk แบบเฉพาะเจาะจง
    connection.invoke("SubscribeKiosk", id);
}

function timeAgo(dateString) {
    const now = new Date();
    const updated = new Date(dateString);
    const diff = Math.floor((now - updated) / 1000); // วินาที

    if (diff < 60) return `${diff} วินาทีที่แล้ว`;
    if (diff < 3600) return `${Math.floor(diff / 60)} นาทีที่แล้ว`;
    if (diff < 86400) return `${Math.floor(diff / 3600)} ชั่วโมงที่แล้ว`;
    return updated.toLocaleString();
}