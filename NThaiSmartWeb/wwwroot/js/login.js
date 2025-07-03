const form = document.getElementById("loginForm");  // หรือใช้ selector อื่น ๆ
form.addEventListener("submit", async (e) => {
    e.preventDefault();
    const data = new FormData(form);
    const response = await fetch('/api/auth/login', { method: 'POST', body: data });

    const res = await response.json();
    if (response.ok) {
        localStorage.setItem('selectedKioskCode', res.kioskCode);
        window.location.href = '/kiosk/list';  // redirect เอง
    } else {
        alert(res.message || 'Login failed');
    }
});