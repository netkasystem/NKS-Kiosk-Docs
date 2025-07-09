let selectedKioskCode = null;
let cardData = null;
let newCard;
let hasCapture;
let faceDetectorLoaded = false;
let faceDetected = false;
let stableSince = null;

const video = document.getElementById("videoInput");
const canvas = document.getElementById("faceCanvas");
const statusElem = document.getElementById("scanResult");
const normalFrame = document.getElementById("normal-frame");
const dangerFrame = document.getElementById("danger-frame");
const successFrame = document.getElementById("success-frame");
var submitBtn = document.getElementById("submitBtn");

function isFacingForward(landmarks) {
    const leftEye = landmarks.getLeftEye();
    const rightEye = landmarks.getRightEye();
    const nose = landmarks.getNose();
    const eyeMidX = (leftEye[0].x + rightEye[3].x) / 2;
    const noseX = nose[3].x;
    const offset = Math.abs(eyeMidX - noseX);
    return offset < 10;
}

async function startFaceRecognition() {
    if (!video) return;

    await faceapi.nets.tinyFaceDetector.loadFromUri('/models');
    await faceapi.nets.faceLandmark68TinyNet.loadFromUri('/models'); // สำหรับ landmark แบบไวและเบา
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

async function detectLoop() {
    if (!faceDetectorLoaded || faceDetected || video.paused || video.ended) {
        requestAnimationFrame(detectLoop);
        return;
    }

    const detection = await faceapi
        .detectSingleFace(video, new faceapi.TinyFaceDetectorOptions())
        .withFaceLandmarks(true);

    if (!detection) {
        showError("❌ ไม่พบใบหน้า กรุณาอยู่ในกรอบกล้อง");
        stableSince = null;
        requestAnimationFrame(detectLoop);
        return;
    }

    const bounds = video.getBoundingClientRect();

    const videoWidth = video.videoWidth;
    const videoHeight = video.videoHeight;

    const videoRatio = videoWidth / videoHeight;
    const containerRatio = bounds.width / bounds.height;

    // คำนวณขนาดวิดีโอจริง (หลัง object-fit: cover)
    let displayWidth, displayHeight, offsetX = 0, offsetY = 0;

    if (containerRatio > videoRatio) {
        // หน้าจอกว้างกว่าวิดีโอ → ครอปบน/ล่าง
        displayWidth = bounds.width;
        displayHeight = bounds.width / videoRatio;
        offsetY = (displayHeight - bounds.height) / 2;
    } else {
        // หน้าจอสูงกว่าวิดีโอ → ครอปซ้าย/ขวา
        displayHeight = bounds.height;
        displayWidth = bounds.height * videoRatio;
        offsetX = (displayWidth - bounds.width) / 2;
    }

    // สัดส่วน scaling (จาก video พิกเซล → DOM พิกเซล)
    const scaleX = displayWidth / videoWidth;
    const scaleY = displayHeight / videoHeight;


    // ✅ NEW: ใช้ landmark หาจุดกลางหน้าแทน box
    const landmarks = detection.landmarks;
    const leftEye = landmarks.getLeftEye();
    const rightEye = landmarks.getRightEye();

    // จุดกลางระหว่างตาซ้าย–ขวา (index 0 กับ 3)
    const rawCenterX = (leftEye[0].x + rightEye[3].x) / 2;
    const rawCenterY = (leftEye[0].y + rightEye[3].y) / 2;

    // สเกลตามขนาดหน้าจอจริง
    const faceCenterX = rawCenterX * scaleX;
    const faceCenterY = rawCenterY * scaleY;

    // ✅ คำนวณจาก box เหมือนเดิมเพื่อวัดขนาดใบหน้า
    const box = detection.alignedRect.box; // ✅ ใช้ box จาก alignedRect
    const boxX = box.x * scaleX;
    const boxY = box.y * scaleY;
    const boxWidth = box.width * scaleX;
    const boxHeight = box.height * scaleY;

    //const faceCenterX = boxX + boxWidth / 2;
    //const faceCenterY = boxY + boxHeight / 2;

    const faceArea = boxWidth * boxHeight;
    const screenArea = bounds.width * bounds.height;
    const faceRatio = faceArea / screenArea;

    const centerX = bounds.width / 2;
    const centerY = bounds.height / 2;
    const maxOffsetX = bounds.width * 0.45;
    const maxOffsetY = bounds.height * 0.45;

    isCentered = (Math.abs(faceCenterX - centerX) < maxOffsetX && Math.abs(faceCenterY - centerY) < maxOffsetY);
    isBigEnough = faceRatio > 0.01; // เดิม 0.020

    console.log("Scaled boxX:", boxX.toFixed(1), "boxY:", boxY.toFixed(1));
    console.log("Scaled center:", faceCenterX.toFixed(1), faceCenterY.toFixed(1));
    console.log("FaceCenter:", faceCenterX.toFixed(1), faceCenterY.toFixed(1));
    console.log("Center:", centerX.toFixed(1), centerY.toFixed(1));
    console.log("OffsetX:", Math.abs(faceCenterX - centerX).toFixed(1));
    console.log("OffsetY:", Math.abs(faceCenterY - centerY).toFixed(1));
    console.log("Allowed Max:", maxOffsetX.toFixed(1), maxOffsetY.toFixed(1));
    console.log(`new check isCentered - ${isCentered}, isBigEnough - ${isBigEnough}`);

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
        showFrame("danger");
        stableSince = null;
        requestAnimationFrame(detectLoop);
        return;
    }

    // เริ่มจับเวลา
    const now = Date.now();
    if (!stableSince) stableSince = now;

    const elapsed = now - stableSince;
    const remaining = 3000 - elapsed;

    if (remaining > 0) {
        const secondsLeft = Math.ceil(remaining / 1000);
        showSuccess(`✅ รอสักครู่... ${secondsLeft}`);
        showFrame("success");
    } else {
        faceDetected = true;
        normalFrame.style.display = "none";
        dangerFrame.style.display = "none";
        successFrame.style.display = "none";
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

        window.Step10.capture_success();
    }

    requestAnimationFrame(detectLoop);
}
function showFrame(type) {
    normalFrame.style.display = type === 'normal' ? 'block' : 'none';
    dangerFrame.style.display = type === 'danger' ? 'block' : 'none';
    successFrame.style.display = type === 'success' ? 'block' : 'none';
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

submitBtn?.addEventListener("click", async (e) => {
    e.preventDefault();
    if (cardData == null) alert("ไม่พบข้อมูลบัตรประชาชน");

    const canvas = document.getElementById("faceCanvas");
    if (!canvas) { alert("❌ ไม่พบ canvas ที่ใช้สำหรับจับภาพ"); return; }

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

    cardData.face_capture = base64Image;
    cardData.KioskCode = GetKioskCode();
    const encrypCardData = encrypt(cardData);

    try {
        const response = await fetch('/api/KioskApi/SaveNationalCardData', {
            method: 'POST',
            headers: { "Content-Type": "application/json", },
            body: JSON.stringify({ EncrypString: encrypCardData })
        });

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error(errorText);
        }
        else {
            const message = await response.text();
            alert(message);
        }
    } catch (error) {
        alert(error.message);
    }
});

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