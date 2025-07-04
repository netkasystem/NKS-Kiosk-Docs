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

    const savedId = localStorage.getItem('selectedKioskCode');
    if (savedId) selectKiosk(savedId);
}).catch(err => console.error("❌ SignalR error: ", err));

connection.onreconnected(() => {
    console.log("🔁 Reconnected");
    // ขอข้อมูล kiosk
    connection.invoke("RequestKioskList");
});

// รับสถานะเครื่องอ่าน
connection.on("KioskStatus", (data) => {
    // 🎯 อัปเดตเครื่องที่เลือกอยู่ (ถ้ามี)
    if (selectedKioskCode && data.kioskCode === selectedKioskCode) {
        console.log(`[${data.timestamp}] ${data.statusCode}: ${data.statusText}`);
        console.log(`[${data.timestamp}] ${data.statusCode}: ${data.statusText}`);
        document.getElementById("kiosk-status-time").innerText = new Date(data.timestamp).toLocaleTimeString();
        document.getElementById("kiosk-status-text").innerText = data.statusText;

        const iconElem = document.getElementById("kiosk-status-icon");
        iconElem.className = "status-icon"; // reset
        iconElem.classList.add(data.statusCode); // เพิ่มสถานะใหม่

        if (data.statusCode === "card_removed") clearCardInfo();
    }
});

// รับข้อมูลบัตร
connection.on("KioskMessage", (data) => { showCardInfo(data); });
function showCardInfo(data) {
    cardData = data;
    const img = document.getElementById("photo");
    img.onload = async () => {
        try {
            console.log("🟢 โหลดรูปบัตรสำเร็จ");
            newCard = true;

            const videoInput = document.getElementById("videoInput");
            if (videoInput) videoInput.style.display = "block";
            const captureBtn = document.getElementById("captureFace");
            if (captureBtn) captureBtn.style.display = "block";
        } catch (err) {
            console.error("🔴 โหลดรูปบัตรล้มเหลว:", err.message);
        }
    };
    img.src = data.photo;

    document.getElementById("citizenID").innerText = data.citizenID;
    document.getElementById("fullNameTH").innerText = data.fullNameTH;
    document.getElementById("fullNameEN").innerText = data.fullNameEN;
    document.getElementById("dob").innerText = new Date(data.dateOfBirth).toLocaleDateString("th-TH");
    document.getElementById("issueDate").innerText = new Date(data.issueDate).toLocaleDateString("th-TH");
    document.getElementById("expireDate").innerText = new Date(data.expireDate).toLocaleDateString("th-TH");

    const addr = data.addressInfo;
    const fullAddr = `${addr.houseNo} ${addr.villageNo} ${addr.lane} ${addr.road} ${addr.subDistrict} ${addr.district} ${addr.province}`.replace(/\s+/g, ' ').trim();
    document.getElementById("address").innerText = fullAddr;
    document.getElementById("issuer").innerText = data.issuer.trim();
}

// ฟังก์ชันเคลียร์ข้อมูลบัตร
function clearCardInfo() {
    cardData = null;
    document.getElementById("photo").src = "/images/icons/id-card-icon.png";
    document.getElementById("citizenID").innerText = "";
    document.getElementById("fullNameTH").innerText = "";
    document.getElementById("fullNameEN").innerText = "";
    document.getElementById("dob").innerText = "";
    document.getElementById("issueDate").innerText = "";
    document.getElementById("expireDate").innerText = "";
    document.getElementById("address").innerText = "";
    document.getElementById("issuer").innerText = "";
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

// เรียกใช้เมื่อคลิก "เลือกตู้"
function selectKiosk(id) {
    var kioskNo = document.getElementById("kiosk-no");
    if (!kioskNo) return;
    kioskNo.innerText = `📡 เชื่อมต่อกับตู้: ${id}`;
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