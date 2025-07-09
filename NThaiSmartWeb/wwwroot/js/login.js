const form = document.getElementById("loginForm");
form?.addEventListener("submit", async (e) => {
    e.preventDefault();
    const formData = new FormData(form);
    const data = {
        username: formData.get("username"),
        password: formData.get("password"),
        rememberMe: formData.get("rememberMe") ?? "off",
        kioskCode: KioskCode ?? ""
    };

    const response = await fetch('/api/auth/login', { method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(data) });
    const res = await response.json();
    if (response.ok) {
        localStorage.setItem('selectedKioskCode', res.kioskCode);
        window.location.href = '/kiosk/list';
    } else {
        alert(res.message || 'Login failed');
    }
});


const urlParams = new URLSearchParams(window.location.search);
const KioskCode = urlParams.get("kioskCode");
const token = urlParams.get("token");

if (!KioskCode) {
    console.log("❌ ไม่พบ KioskCode");
} else {
    console.log("ตู้นี้คือ:", KioskCode);
}

if (KioskCode && token) SSOLogin();

SSOLogin = async function () {


    const data = { kioskCode: KioskCode ?? "", token: token ?? "" };

    if (response.ok) {
        localStorage.setItem('selectedKioskCode', res.kioskCode);
        window.location.href = '/Step/Step1';
    }

    try {
        const response = await fetch('/api/auth/sso', { method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(data) });
        const res = await response.json();

        if (response.ok) {
            // ✅ เก็บ kioskCode ไว้ใช้ภายหลัง (เช่น redirect กลับ)
            localStorage.setItem('selectedKioskCode', res.kioskCode);

            // ✅ ไปขั้นตอนถัดไปหลัง SSO สำเร็จ
            window.location.href = '/Step/Step1';
        } else {
            // ❌ กรณี token หรือ kioskCode ผิด
            console.error("SSO Login Failed:", res.message || res.error || res);
            alert("⚠️ ไม่สามารถเข้าสู่ระบบได้ กรุณาตรวจสอบ token หรือ kiosk");
        }

    } catch (err) {
        console.error("❌ Error calling /api/auth/sso", err);
        alert("❌ เกิดข้อผิดพลาดในการเชื่อมต่อกับเซิร์ฟเวอร์");
    }
}
