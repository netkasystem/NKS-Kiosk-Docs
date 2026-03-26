let selectedKioskCode = null;
let cardData = null;
let newCard;
let hasCapture;
let faceDetectorLoaded = false;
let faceDetected = false;
let stableSince = null;

let canPlayFocusAudio = true;
let tempCanvas = null; // reuse canvas แทนสร้างใหม่ทุก frame

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
        audioLook.currentTime = 0;

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
    const expectedCenterX = 0.5; // ตำแหน่ง X ที่คุณอยากให้หน้ากลางจอ
    const expectedCenterY = 0.6; // ตำแหน่ง Y ที่คุณอยากให้หน้ากลางจอ
    const toleranceX = 0.10;
    const toleranceY = 0.10;

    const isCentered = Math.abs(faceCenterX_ratio - expectedCenterX) < toleranceX
        && Math.abs(faceCenterY_ratio - expectedCenterY) < toleranceY;
    const isBigEnough = faceRatio > 0.06 && faceRatio < 0.22

    // ✅ log ทุกอย่าง
    //console.log("📷 VIDEO SIZE:", videoWidth, videoHeight);
    //console.log("🖼️  SCREEN SIZE:", vw, vh);
    //console.log("🎯 faceCenterX:", faceCenterX, `(${faceCenterX_ratio.toFixed(3)}) => ${Math.abs(faceCenterX_ratio - expectedCenterX) < toleranceX}`);
    //console.log("🎯 faceCenterY:", faceCenterY, `(${faceCenterY_ratio.toFixed(3)}) => ${Math.abs(faceCenterY_ratio - expectedCenterY) < toleranceY}`);
    //console.log("📐 faceAreaRatio:", faceArea_ratio.toFixed(4));
    //console.log("✅ isCentered:", isCentered, "isBigEnough:", isBigEnough);

    // วาดภาพจาก video ลง canvas ชั่วคราว เพื่อตรวจความชัด (reuse canvas)
    if (!tempCanvas) {
        tempCanvas = document.createElement('canvas');
        tempCanvas.width = video.videoWidth;
        tempCanvas.height = video.videoHeight;
    }
    const ctx = tempCanvas.getContext('2d');
    ctx.drawImage(video, 0, 0, tempCanvas.width, tempCanvas.height);

    const isSharp = isImageSharpEnough(tempCanvas, box);
    if (!isCentered || !isBigEnough || !isSharp) {
        if (!audioLook.paused) {
            audioLook.pause();
            audioLook.currentTime = 0;
        }

        if (!isSharp) {
            showError("⚠️ ภาพไม่ชัด กรุณาอยู่นิ่ง และใกล้กล้อง");
        } else if (faceRatio < 0.06) {
            showError("⚠️ กรุณาขยับเข้ามาใกล้กล้องมากขึ้น");
        } else if (faceRatio > 0.22) {
            showError("⚠️ กรุณาถอยหลังออกจากกล้องมากขึ้น");
        } else if (!isCentered) {
            showError("⚠️ กรุณาขยับให้ใบหน้าอยู่กลางจอ");
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
    const secondsRemaining = 1 - secondsPassed;

    if (secondsRemaining > 0) {
        showSuccess(`✅ รอสักครู่... ${secondsRemaining}`);
        showFrame("success");

        if (audioLook.paused) audioLook.play();

        // ถ่ายภาพเก็บไว้
        captureFrameToBase64(); // 👈 แยกฟังก์ชันมาเก็บภาพ
    } else {
        faceDetected = true;
        // ครบ 1 วินาทีแล้ว → ไปขั้นต่อไป
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
    const canvas = document.getElementById("faceCanvas");
    const cctx = canvas.getContext("2d");

    // ใช้ขนาด native ของกล้องเต็มๆ ไม่บีบตาม display
    canvas.width  = video.videoWidth;
    canvas.height = video.videoHeight;

    cctx.drawImage(video, 0, 0, canvas.width, canvas.height);

    // jpeg quality 0.92 — คมชัดพอ ขนาดไฟล์เล็กกว่า png มาก
    const base64Image = canvas.toDataURL("image/jpeg", 0.92);
    setCapture(base64Image);
}

function showFrame(type) {
    normalFrame.style.display = type === 'normal' ? 'block' : 'none';
    dangerFrame.style.display = type === 'danger' ? 'block' : 'none';
    successFrame.style.display = type === 'success' ? 'block' : 'none';
}

function isImageSharpEnough(canvas, box, threshold = 20) {
    const ctx = canvas.getContext('2d');

    // เช็คเฉพาะบริเวณใบหน้า ไม่ต้องวนทั้งภาพ
    const x = Math.max(0, Math.floor(box.x));
    const y = Math.max(0, Math.floor(box.y));
    const w = Math.min(canvas.width - x, Math.floor(box.width));
    const h = Math.min(canvas.height - y, Math.floor(box.height));
    const imageData = ctx.getImageData(x, y, w, h);

    // sample ทุก 4 pixel เพื่อลด load
    const step = 4;
    let sum = 0, sumSq = 0, count = 0;
    for (let i = 0; i < imageData.data.length; i += 4 * step) {
        const avg = (imageData.data[i] + imageData.data[i + 1] + imageData.data[i + 2]) / 3;
        sum += avg;
        sumSq += avg * avg;
        count++;
    }
    const mean = sum / count;
    const variance = sumSq / count - mean * mean;

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