let selectedKioskCode = null;

const connection = new signalR.HubConnectionBuilder().withUrl("/NThaiSmartHub").withAutomaticReconnect().build();
connection.start().then(() => {
    console.log("✅ Web Connected");
    connection.invoke("RequestKioskList"); // ขอข้อมูล kiosk เมื่อโหลด

    setInterval(() => {
        if (connection.state === signalR.HubConnectionState.Connected) {
            connection.invoke("RequestKioskList");
        }
    }, 2 * 60 * 1000);

    loadSelectedKiosk();
}).catch(err => console.error("❌ SignalR error: ", err));

connection.onreconnected(() => {
    console.log("🔁 Reconnected");
    connection.invoke("RequestKioskList");
});

// รับสถานะเครื่องอ่าน เช่น .card_removed, .ready
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
    selectedKioskCode = id;
    localStorage.setItem('selectedKioskCode', id);
    connection.invoke("SubscribeKiosk", id);
}

function loadSelectedKiosk() {
    const savedId = localStorage.getItem('selectedKioskCode');
    if (savedId) {
        selectKiosk(savedId);
    }
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

generateSetupKiosk = async () => {
    await DownloadFileKiosk({ api: "/api/KioskApi/DownloadSetupKiosk", method: "POST" });
}
generateDocker = async () => {
    await DownloadFileKiosk({ api: "/api/KioskApi/DownloadSetupDocker", method: "POST" });
}

window.DownloadFileKiosk = async function (req) {
    const response = await fetch(req.api, { method: req.method ?? "POST" });

    if (!response.ok) { alert("❌ ไม่สามารถดาวน์โหลดไฟล์ได้"); return; }

    const blob = await response.blob();
    const contentDisposition = response.headers.get("Content-Disposition");
    let fileName = "download.sh";

    if (contentDisposition) {
        let match = contentDisposition.match(/filename\*\=UTF-8''(.+?)(;|$)/);
        if (match && match[1]) {
            fileName = decodeURIComponent(match[1]);
        } else {
            match = contentDisposition.match(/filename="?([^\";]+)"?/);
            if (match && match[1]) {
                fileName = match[1];
            }
        }
    }

    const url = window.URL.createObjectURL(blob);
    const a = document.createElement("a");
    a.href = url;
    a.download = fileName; // ✅ ดึงจาก header API
    document.body.appendChild(a);
    a.click();
    a.remove();
    window.URL.revokeObjectURL(url);
}

const logoutBtn = document.getElementById("logout");
logoutBtn.addEventListener("click", async (e) => {
    e.preventDefault();

    const response = await fetch('/api/auth/logout', {
        method: 'POST'
    });

    if (response.ok) {
        window.location.href = '/login'; // หรือ '/'; แล้วแต่คุณออกแบบ
    } else {
        const res = await response.json();
        alert(res.message || 'Logout failed');
    }
});

function isFacingForward(landmarks) {
    const leftEye = landmarks.getLeftEye();
    const rightEye = landmarks.getRightEye();
    const nose = landmarks.getNose();
    const eyeMidX = (leftEye[0].x + rightEye[3].x) / 2;
    const noseX = nose[3].x;
    const offset = Math.abs(eyeMidX - noseX);
    return offset < 10;
}

let newCard;
let hasCapture;
const video = document.getElementById("videoInput");
const canvas = document.getElementById("faceCanvas");
const captureBtn = document.getElementById("captureFace");
const statusElem = document.getElementById("identity-status");

async function startFaceRecognition() {
    if (!video) return;

    let faceDetectorLoaded = false;

    // โหลดโมเดล
    Promise.all([
        faceapi.nets.tinyFaceDetector.loadFromUri('/models')
    ]).then(() => {
        faceDetectorLoaded = true;
        navigator.mediaDevices.getUserMedia({ video: true })
            .then(stream => {
                video.srcObject = stream;
            }).catch(err => {
                statusElem.innerText = "❌ ไม่สามารถเปิดกล้องได้: " + err;
            });
    });

    captureBtn.addEventListener("click", async () => {
        if (!faceDetectorLoaded) {
            statusElem.innerText = "⏳ กำลังโหลดโมเดล...";
            return;
        }

        const detection = await faceapi.detectSingleFace(video, new faceapi.TinyFaceDetectorOptions());

        if (!detection) {
            statusElem.innerText = "❌ ไม่พบใบหน้า กรุณาอยู่ในกรอบกล้อง";
            statusElem.classList.remove("text-success");
            statusElem.classList.add("text-danger");
            return;
        }

        

        const box = detection.box;
        const { width: vw, height: vh } = video.getBoundingClientRect();

        // 🔍 เงื่อนไข:
        const faceArea = box.width * box.height;
        const screenArea = vw * vh;

        const faceRatio = faceArea / screenArea;
        const faceCenterX = box.x + box.width / 2;
        const faceCenterY = box.y + box.height / 2;

        const isCentered = (
            faceCenterX > vw * 0.25 && faceCenterX < vw * 0.75 &&
            faceCenterY > vh * 0.25 && faceCenterY < vh * 0.75
        );

        const isBigEnough = faceRatio > 0.05; // 5% ของจอขึ้นไป

        if (!isCentered || !isBigEnough) {
            showError("⚠️ กรุณาให้ใบหน้าอยู่กลางจอและใกล้กล้องมากขึ้น");
            return;
        }

        // ✅ แสดงภาพนิ่ง
        const context = canvas.getContext("2d");
        canvas.width = video.videoWidth;
        canvas.height = video.videoHeight;
        context.drawImage(video, 0, 0, canvas.width, canvas.height);

        video.style.display = "none";
        canvas.style.display = "block";
        captureBtn.style.display = "none";

        showSuccess("✅ ตรวจพบใบหน้าแล้ว");
    });
}

function captureFrame(video) {
    const canvas = document.createElement('canvas');
    canvas.width = video.videoWidth;
    canvas.height = video.videoHeight;
    const ctx = canvas.getContext('2d');
    ctx.drawImage(video, 0, 0, canvas.width, canvas.height);

    const dataUrl = canvas.toDataURL('image/png');
    console.log('Captured image (base64):', dataUrl);
    hasCapture = true;
    newCard = false;
    // ทำอะไรต่อ เช่น แสดงรูป, ส่ง server, save ฯลฯ
}

function showError(msg) {
    statusElem.innerText = msg;
    statusElem.classList.remove("text-success");
    statusElem.classList.add("text-danger");
}

function showSuccess(msg) {
    statusElem.innerText = msg;
    statusElem.classList.remove("text-danger");
    statusElem.classList.add("text-success");
}

window.addEventListener("DOMContentLoaded", startFaceRecognition);