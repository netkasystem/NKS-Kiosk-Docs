const urlParams = new URLSearchParams(window.location.search);
const KioskCode = urlParams.get("KioskCode");
if (!KioskCode) {
    console.log("❌ ไม่พบ KioskCode");
} else {
    console.log("ตู้นี้คือ:", KioskCode);
}

const form = document.getElementById("loginForm");
form.addEventListener("submit", async (e) => {
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