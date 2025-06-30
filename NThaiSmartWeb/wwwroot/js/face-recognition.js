function isFacingForward(landmarks) {
    const leftEye = landmarks.getLeftEye();
    const rightEye = landmarks.getRightEye();
    const nose = landmarks.getNose();
    const eyeMidX = (leftEye[0].x + rightEye[3].x) / 2;
    const noseX = nose[3].x;
    const offset = Math.abs(eyeMidX - noseX);
    return offset < 10;
}

let newCard = false;

async function startFaceRecognition() {
    await faceapi.nets.tinyFaceDetector.loadFromUri('/models');
    await faceapi.nets.faceLandmark68Net.loadFromUri('/models');

    const video = document.getElementById('videoInput');
    const stream = await navigator.mediaDevices.getUserMedia({ video: {} });
    video.srcObject = stream;

    video.addEventListener('play', () => {
        setInterval(async () => {
            const detection = await faceapi
                .detectSingleFace(video, new faceapi.TinyFaceDetectorOptions())
                .withFaceLandmarks();

            if (!detection) {
                console.warn("❌ ไม่พบใบหน้าผู้ใช้");
                return;
            }

            if (isFacingForward(detection.landmarks)) {
                captureFrame(video);
            }
        }, 500); // ทุก 0.5 วินาที หรือปรับตามต้องการ
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

    // ทำอะไรต่อ เช่น แสดงรูป, ส่ง server, save ฯลฯ
}

window.addEventListener("DOMContentLoaded", startFaceRecognition);