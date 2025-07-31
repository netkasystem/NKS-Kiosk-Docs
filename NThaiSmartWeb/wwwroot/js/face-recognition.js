let selectedKioskCode = null;
let cardData = null;
let newCard;
let hasCapture;
let faceDetectorLoaded = false;
let faceDetected = false;
let stableSince = null;

let canPlayFocusAudio = true;

const video = document.getElementById("videoInput");
const canvas = document.getElementById("faceCanvas");
const statusElem = document.getElementById("scanResult");
const normalFrame = document.getElementById("normal-frame");
const dangerFrame = document.getElementById("danger-frame");
const successFrame = document.getElementById("success-frame");
const audioFocus = document.getElementById("audio-focus"); // เสียงเมื่อไม่พบใบหน้า
const audioLook = document.getElementById("audio-look"); // เสียงตอนนับถอยหลัง.

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

    const detection = await faceapi.detectSingleFace(video, new faceapi.TinyFaceDetectorOptions());

    if (!detection) {
        showError("❌ ไม่พบใบหน้า กรุณาอยู่ในกรอบกล้อง");
        stableSince = null;

        audioLook.pause(); // หยุดเสียงนับถอยหลัง ถ้ากำลังเล่นอยู่
        audioLook.currentTime = 3000;

        if (audioFocus.paused) { // เช็คว่าเสียงยังไม่ได้เล่นอยู่
            audioFocus.play(); // เล่นเสียง "ให้อยู่ในกรอบ"
        }

        requestAnimationFrame(detectLoop);
        return;
    }
    if (!audioFocus.paused) {
        audioFocus.pause();
        audioFocus.currentTime = 0;
    }

    const videoWidth = video.videoWidth;
    const videoHeight = video.videoHeight;

    // กล่องที่ตรวจจับได้
    const box = detection.box;

    // สัดส่วนของตำแหน่งใบหน้าในวิดีโอจริง (ไม่ใช่จอ)
    const faceCenterX_ratio = (box.x + box.width / 2) / videoWidth;
    const faceCenterY_ratio = (box.y + box.height / 2) / videoHeight;
    const faceArea_ratio = (box.width * box.height) / (videoWidth * videoHeight);

    // ขนาดบนจอจริง
    const { width: vw, height: vh } = video.getBoundingClientRect();

    // เปลี่ยนจากอัตราส่วนเป็นตำแหน่งบนจอ
    const faceCenterX = faceCenterX_ratio * vw;
    const faceCenterY = faceCenterY_ratio * vh;
    const faceRatio = faceArea_ratio; // ไม่ต้องเปลี่ยนแล้ว เพราะใช้จากอัตราส่วน

    // เช็กเงื่อนไข
    const expectedCenterY = 0.7; // ตำแหน่ง Y ที่คุณอยากให้หน้ากลางจอ
    const toleranceX = 0.1;
    const toleranceY = 0.05;

    const isCentered = Math.abs(faceCenterX_ratio - 0.5) < toleranceX && Math.abs(faceCenterY_ratio - expectedCenterY) < toleranceY;
    const isBigEnough = faceRatio > 0.010;

    // ✅ log ทุกอย่าง
    //console.log("📷 VIDEO SIZE:", videoWidth, videoHeight);
    //console.log("🖼️  SCREEN SIZE:", vw, vh);
    //console.log("🎯 faceCenterX:", faceCenterX, `(${faceCenterX_ratio.toFixed(3)})`);
    //console.log("🎯 faceCenterY:", faceCenterY, `(${faceCenterY_ratio.toFixed(3)})`);
    //console.log("📐 faceAreaRatio:", faceArea_ratio.toFixed(4));
    //console.log("✅ isCentered:", isCentered, "isBigEnough:", isBigEnough);

    // วาดภาพจาก video ลง canvas ชั่วคราว เพื่อตรวจความชัด
    const tempCanvas = document.createElement('canvas');
    const ctx = tempCanvas.getContext('2d');
    tempCanvas.width = video.videoWidth;
    tempCanvas.height = video.videoHeight;
    ctx.drawImage(video, 0, 0, tempCanvas.width, tempCanvas.height);

    const isSharp = isImageSharpEnough(tempCanvas);
    if (!isCentered || !isBigEnough || !isSharp) {
        if (!audioLook.paused) {
            audioLook.pause();
            audioLook.currentTime = 0;
        }
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

    const secondsPassed = Math.floor((now - stableSince) / 1000);
    const secondsRemaining = 2 - secondsPassed;

    if (secondsRemaining > 1) {
        showSuccess(`✅ รอสักครู่... ${secondsRemaining}`);
        if (audioLook.paused) audioLook.play();
    } else if (secondsRemaining > 0) {
        showSuccess(`✅ รอสักครู่... ${secondsRemaining}`);
        showFrame("success");

        if (audioLook.paused) audioLook.play();

        // ถ่ายภาพเก็บไว้
        captureFrameToBase64(); // 👈 แยกฟังก์ชันมาเก็บภาพ
    } else {
        faceDetected = true;
        // ครบ 2 วินาทีแล้ว → ไปขั้นต่อไป
        audioLook.pause();
        audioLook.currentTime = 0;

        normalFrame.style.display = "none";
        dangerFrame.style.display = "none";
        successFrame.style.display = "none";

        video.style.display = "none";
        canvas.style.display = "block";

        showSuccess("✅ ตรวจพบใบหน้าแล้ว");
        document.getElementById("submitBtn").style.display = "inline-block";
        window.Step10.capture_success();
    }

    requestAnimationFrame(detectLoop);
}

function captureFrameToBase64() {
    // แสดงภาพนิ่ง
    const canvas = document.getElementById("faceCanvas");
    const cctx = canvas.getContext("2d");

    // ขนาดจอแสดงผลจริง
    const rect = video.getBoundingClientRect();
    canvas.width = rect.width;
    canvas.height = rect.height;

    // ขนาดกล้องจริง (อาจเป็น 1280x720 หรือ 640x480)
    const videoWidth = video.videoWidth;
    const videoHeight = video.videoHeight;

    // คำนวณอัตราส่วนของ container
    const aspectCanvas = canvas.width / canvas.height;
    const aspectVideo = videoWidth / videoHeight;

    let sx, sy, sWidth, sHeight;

    if (aspectVideo > aspectCanvas) {
        // กล้องกว้างเกิน → ครอปด้านข้าง
        sHeight = videoHeight;
        sWidth = videoHeight * aspectCanvas;
        sx = (videoWidth - sWidth) / 2;
        sy = 0;
    } else {
        // กล้องสูงเกิน → ครอปด้านบนล่าง
        sWidth = videoWidth;
        sHeight = videoWidth / aspectCanvas;
        sx = 0;
        sy = (videoHeight - sHeight) / 2;
    }

    // วาดเฉพาะส่วนที่ครอปลง canvas
    cctx.drawImage(video, sx, sy, sWidth, sHeight, 0, 0, canvas.width, canvas.height);

    // ✅ แปลงภาพใน canvas เป็น base64
    const base64Image = canvas.toDataURL("image/png"); // หรือ "image/jpeg"
    setCapture(base64Image);
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