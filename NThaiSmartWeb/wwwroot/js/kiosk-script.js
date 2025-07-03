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
const statusElem = document.getElementById("scanResult");

let faceDetectorLoaded = false;
let faceDetected = false;

async function startFaceRecognition() {
    if (!video) return;

    await faceapi.nets.tinyFaceDetector.loadFromUri('/models');
    faceDetectorLoaded = true;

    try {
        const stream = await navigator.mediaDevices.getUserMedia({ video: true });
        video.srcObject = stream;
    } catch (err) {
        showError("❌ ไม่สามารถเปิดกล้องได้: " + err);
        return;
    }

    detectLoop();
}
let stableSince = null;

async function detectLoop() {
    if (!faceDetectorLoaded || faceDetected || video.paused || video.ended) {
        requestAnimationFrame(detectLoop);
        return;
    }

    const detection = await faceapi.detectSingleFace(video, new faceapi.TinyFaceDetectorOptions());

    if (!detection) {
        showError("❌ ไม่พบใบหน้า กรุณาอยู่ในกรอบกล้อง");
        stableSince = null;
        requestAnimationFrame(detectLoop);
        return;
    }

    const box = detection.box;
    const { width: vw, height: vh } = video.getBoundingClientRect();
    const faceArea = box.width * box.height;
    const screenArea = vw * vh;
    const faceRatio = faceArea / screenArea;
    const faceCenterX = box.x + box.width / 2;
    const faceCenterY = box.y + box.height / 2;

    const isCentered = (faceCenterX > vw * 0.25 && faceCenterX < vw * 0.75 && faceCenterY > vh * 0.25 && faceCenterY < vh * 0.75);
    const isBigEnough = faceRatio > 0.05;

    // วาดภาพจาก video ลง canvas ชั่วคราว เพื่อตรวจความชัด
    const tempCanvas = document.createElement('canvas');
    const ctx = tempCanvas.getContext('2d');
    tempCanvas.width = video.videoWidth;
    tempCanvas.height = video.videoHeight;
    ctx.drawImage(video, 0, 0, tempCanvas.width, tempCanvas.height);

    const isSharp = isImageSharpEnough(tempCanvas);

    if (!isCentered || !isBigEnough || !isSharp) {
        if (!isSharp) {
            showError("⚠️ ภาพไม่ชัด กรุณาอยู่นิ่ง และใกล้กล้อง");
        } else {
            showError("⚠️ กรุณาให้ใบหน้าอยู่กลางจอและใกล้กล้องมากขึ้น");
        }
        stableSince = null;
        requestAnimationFrame(detectLoop);
        return;
    }

    // เริ่มจับเวลา
    const now = Date.now();
    if (!stableSince) stableSince = now;

    const elapsed = now - stableSince;
    const remaining = 1000 - elapsed;

    if (remaining > 0) {
        const secondsLeft = Math.ceil(remaining / 1000);
        showSuccess(`✅ รอสักครู่... ${secondsLeft}`);
    } else {
        faceDetected = true;

        // แสดงภาพนิ่ง
        const canvas = document.getElementById("faceCanvas");
        const cctx = canvas.getContext("2d");
        canvas.width = video.videoWidth;
        canvas.height = video.videoHeight;
        cctx.drawImage(video, 0, 0, canvas.width, canvas.height);

        video.style.display = "none";
        canvas.style.display = "block";

        showSuccess("✅ ตรวจพบใบหน้าแล้ว");
        const submitBtn = document.getElementById("submitBtn");
        submitBtn.style.display = "inline-block";
    }

    requestAnimationFrame(detectLoop);
}

function isImageSharpEnough(canvas, threshold = 20) {
    const ctx = canvas.getContext('2d');
    const imageData = ctx.getImageData(0, 0, canvas.width, canvas.height);
    const gray = [];

    // แปลงเป็น grayscale
    for (let i = 0; i < imageData.data.length; i += 4) {
        const avg = (imageData.data[i] + imageData.data[i + 1] + imageData.data[i + 2]) / 3;
        gray.push(avg);
    }

    // คำนวณความแตกต่างของ pixel เพื่อนิยามความชัด (ความแปรปรวน)
    let sum = 0, sumSq = 0;
    for (const g of gray) {
        sum += g;
        sumSq += g * g;
    }
    const mean = sum / gray.length;
    const variance = sumSq / gray.length - mean * mean;

    return variance > threshold; // ยิ่งมากยิ่งชัด
}

document.getElementById("submitBtn").addEventListener("click", async (e) => {
    e.preventDefault();
    const canvas = document.getElementById("faceCanvas");
    if (!canvas) { alert("❌ ไม่พบ canvas ที่ใช้สำหรับจับภาพ");  return; }

    // --- Resize ---
    const resizedCanvas = document.createElement("canvas");
    const targetWidth = 300;
    const targetHeight = 300;
    resizedCanvas.width = targetWidth;
    resizedCanvas.height = targetHeight;

    const resizedCtx = resizedCanvas.getContext("2d");
    resizedCtx.drawImage(canvas, 0, 0, targetWidth, targetHeight);

    const dataUrl = resizedCanvas.toDataURL("image/jpeg", 0.7);
    const base64Image = dataUrl.split(',')[1];
     
    // --- ส่งต่อ ---
    // information จาก บัตรประชาชน
    const encryptedData = encrypt({
        KioskCode: selectedKioskCode,
        citizenID: document.getElementById("citizenID").innerText,
        fullNameTH: document.getElementById("fullNameTH").innerText,
        fullNameEN: document.getElementById("fullNameEN").innerText,
        dateOfBirth: document.getElementById("dob").innerText,
        issueDate: document.getElementById("issueDate").innerText,
        expireDate: document.getElementById("expireDate").innerText,
        address: document.getElementById("address").innerText,
        issuer: document.getElementById("issuer").innerText,
        face_capture: base64Image 
    });

    try {
        const response = await fetch('/api/KioskApi/SaveNationalCardData', {
            method: 'POST',
            headers: { "Content-Type": "application/json", },
            body: JSON.stringify({ EncrypString: encryptedData })
        });

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(errorText);
        }
        alert(response.message);
    } catch (error) { 
        alert("❌ ส่งภาพไม่สำเร็จ: " + error.message);
    }
});





// encrypt/decrypt data 

const key = CryptoJS.enc.Utf8.parse("Netk@Sy$temKi0sk"); // 16-byte key
function encrypt(payload) {
    const jsonString = JSON.stringify(payload);
    const encrypted = CryptoJS.AES.encrypt(jsonString, key, {
        mode: CryptoJS.mode.ECB,
        padding: CryptoJS.pad.Pkcs7
    });
    return encrypted.toString(); // Base64 string
}

function decrypt(ciphertextBase64) {
    const decrypted = CryptoJS.AES.decrypt(ciphertextBase64, key, {
        mode: CryptoJS.mode.ECB,
        padding: CryptoJS.pad.Pkcs7
    });
    return decrypted.toString(CryptoJS.enc.Utf8);
}

// ฟังก์ชันแสดงผล
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