const form = document.getElementById("loginForm");
form?.addEventListener("submit", async (e) => {
    e.preventDefault();
    const formData = new FormData(form);
    const data = {
        username: formData.get("username"),
        password: formData.get("password"),
        rememberMe: formData.get("rememberMe") ?? "off",
        kioskCode: kiosk_code ?? ""
    };

    ajaxCommon.post("/api/auth/login", data,
        (res) => { AfterAuthen(res) },
        (res) => { alert(res.message || 'Login failed'); });
});

const urlParams = new URLSearchParams(window.location.search);
const kiosk_code = urlParams.get("kiosk_code");
const token = urlParams.get("token");

async function SSOLogin() {
    const data = {
        kiosk_code: kiosk_code ?? "",
        token: token ?? ""
    };

    try {
        const response = await fetch('/api/auth/sso', { method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(data) });
        const res = await response.json();

        if (response.ok) {
            AfterAuthen(res);
        } else {
            console.error("SSO Login Failed:", res.message || res.error || res);
        }
    } catch (err) {
        console.error("❌ Error calling /api/auth/sso", err);
        alert("❌ เกิดข้อผิดพลาดในการเชื่อมต่อกับเซิร์ฟเวอร์");
    }
}

function AfterAuthen(res) {
    //kioskcode
    SetKioskCode(res.kioskCode);
    localStorage.setItem('kioskHomeDelaySec', res.kioskHomeDelaySec);
    localStorage.setItem('kioskWaitBrokenCardSec', res.kioskWaitBrokenCardSec);
    localStorage.setItem('kioskReadStepSec', res.kioskReadStepSec);
    localStorage.setItem('kioskReadStepScanSec', res.kioskReadStepScanSec);

    if (!kiosk_code) {
        next_page('/kiosk/setup', 0.5);
    } else {
        next_page('/Step/Step1', 0.5);
    }
}

window.addEventListener('DOMContentLoaded', () => {
    if (!kiosk_code) {
        console.log("❌ ไม่พบ KioskCode");
    } else {
        console.log("ตู้นี้คือ:", kiosk_code);
    }

    if (kiosk_code && token) SSOLogin();
});