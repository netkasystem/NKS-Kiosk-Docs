const urlParams = new URLSearchParams(window.location.search);
const kiosk_code = urlParams.get("kiosk_code");
const token = urlParams.get("token");
const form = document.getElementById("loginForm");
const passwordInput = form?.querySelector("[name='password']");

form?.addEventListener("submit", async (e) => {
    e.preventDefault();
    const formData = new FormData(form);
    const rawPassword = formData.get("password");
    const isHashed = passwordInput.getAttribute("data-ishash") === "true";

    const data = {
        username: formData.get("username"),
        password: isHashed ? rawPassword : CryptoJS.MD5(rawPassword).toString(),
        rememberMe: formData.get("rememberMe") ?? "off",
        kioskCode: kiosk_code ?? ""
    };

    if (data.rememberMe === "on") {
        SetLoginDetail(data);
    } else {
        SetLoginDetail(null);
    }

    ajaxCommon.post("/api/auth/login", data,
        (res) => { AfterAuthen(res) },
        (res) => { alert(res.responseJSON?.message || 'Login failed'); });
});

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

    if (res.hasToken) {
        next_page('/Step/Step1', 0.5);
    } else {
        next_page('/kiosk/setup', 0.5);
    }
}

// ฟังก์ชันนี้จะอ่านค่าจาก localStorage และใส่กลับเข้า form
function LoadLoginDetailToForm(form) {
    if (typeof window.GetLoginDetail !== "function") return;

    const loginDetail = window.GetLoginDetail();
    if (!loginDetail) return;

    // โหลดจาก localStorage
    if (loginDetail) {
        form.querySelector("[name='username']").value = loginDetail.username ?? "";
        if (loginDetail.password) {
            passwordInput.value = loginDetail.password;
            passwordInput.setAttribute("data-ishash", "true"); // <-- บอกว่าเป็น hash แล้ว
        }
        form.querySelector("[name='rememberMe']").checked = loginDetail.rememberMe === "on";
    }

    // ถ้ามีการแก้ไข password → ให้ลบ data-ishash ออก
    passwordInput.addEventListener("input", () => { passwordInput.removeAttribute("data-ishash"); });
}

window.addEventListener('DOMContentLoaded', () => {
    if (location.pathname?.toLowerCase() == "/login") {
        if (!kiosk_code) {
            console.log("❌ ไม่พบ KioskCode");
        } else {
            console.log("ตู้นี้คือ:", kiosk_code);
        }

        if (kiosk_code && token) SSOLogin();

        LoadLoginDetailToForm(form);
    }
});