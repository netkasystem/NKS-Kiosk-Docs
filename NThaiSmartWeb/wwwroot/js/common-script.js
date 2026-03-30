// ===================== i18n =====================
window._i18n = { langs: [], words: {}, current: localStorage.getItem("lang") || "th" };

window.loadTranslate = async function (forceRefresh = false) {
    try {
        if (!forceRefresh) {
            const cached = localStorage.getItem("_i18n_data");
            if (cached) {
                const list = JSON.parse(cached);
                _i18n.langs = list;
                list.forEach(l => {
                    try { _i18n.words[l.code] = l.words ? JSON.parse(l.words) : {}; } catch { _i18n.words[l.code] = {}; }
                });
                return;
            }
        }
        const res = await fetch("/api/KioskApi/GetTranslate");
        if (!res.ok) return;
        const list = await res.json();
        localStorage.setItem("_i18n_data", JSON.stringify(list));
        _i18n.langs = list;
        list.forEach(l => {
            try { _i18n.words[l.code] = l.words ? JSON.parse(l.words) : {}; } catch { _i18n.words[l.code] = {}; }
        });
    } catch (e) { console.error("loadTranslate error:", e); }
};

window.t = function (key) {
    return _i18n.words[_i18n.current]?.[key] ?? _i18n.words["en"]?.[key] ?? key;
};

window.setLang = function (code) {
    _i18n.current = code;
    localStorage.setItem("lang", code);
    document.querySelectorAll("[data-i18n]").forEach(el => {
        el.textContent = t(el.getAttribute("data-i18n"));
    });
    document.documentElement.lang = code;
    const btn = document.getElementById("lang-switch-btn");
    if (btn) {
        const lang = _i18n.langs.find(l => l.code === code);
        if (lang) btn.innerHTML = `<i class="${lang.icon}"></i>`;
    }
};

window.applyTranslate = function () {
    document.querySelectorAll("[data-i18n]").forEach(el => {
        el.textContent = t(el.getAttribute("data-i18n"));
    });
};

// ===================== /i18n =====================

window.DownloadFile = async function (req) {
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

// encrypt/decrypt data
const key = CryptoJS.enc.Utf8.parse("Netk@Sy$temKi0sk"); // 16-byte key
window.encrypt = function (payload) {
    const jsonString = JSON.stringify(payload);
    const encrypted = CryptoJS.AES.encrypt(jsonString, key, { mode: CryptoJS.mode.ECB, padding: CryptoJS.pad.Pkcs7 });
    return encrypted.toString(); // Base64 string
}

window.decrypt = function (ciphertextBase64) {
    const decrypted = CryptoJS.AES.decrypt(ciphertextBase64, key, { mode: CryptoJS.mode.ECB, padding: CryptoJS.pad.Pkcs7 });
    return decrypted.toString(CryptoJS.enc.Utf8);
}

window.resizeImage = function (imgBase64, size) {
    return new Promise((resolve, reject) => {
        const img = new Image();
        img.onload = function () {
            const canvas = document.createElement('canvas');
            const ctx = canvas.getContext('2d');

            const ratio = img.width / img.height;

            if (img.width > img.height) {
                canvas.width = size;
                canvas.height = size / ratio;
            } else {
                canvas.height = size;
                canvas.width = size * ratio;
            }

            ctx.drawImage(img, 0, 0, canvas.width, canvas.height);

            const resizedBase64 = canvas.toDataURL("image/jpeg", 0.8);
            resolve(resizedBase64);
        };

        img.onerror = function (err) {
            reject(err);
        };

        img.src = imgBase64;
    });
};

const logoutBtn = document.getElementById("logout");
logoutBtn?.addEventListener("click", async (e) => {
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

const CountdownInterval = function (ele, t, func) {

}

const findNextStep = async (current) => {
    const maxStep = 30;
    for (let i = current + 1; i <= maxStep; i++) {
        try {
            const res = await fetch(`/Step/Step${i}`, { method: 'HEAD' });
            if (res.ok) return `/Step/Step${i}`;
        } catch (_) { }
    }
    return "/Step/StepEnd";
};

let timeoutNextPage;
const next_page = async (href, time_sec = 0) => {
    if (!href && location.pathname.startsWith("/Step/Step")) {
        const match = location.pathname.match(/\/Step\/Step(\d+)/);
        href = match ? await findNextStep(parseInt(match[1])) : "/Step/StepEnd";
    }
    timeoutNextPage = setTimeout(() => { window.location.href = href; }, time_sec * 1000);
}
const cancelNextPage = () => { if (timeoutNextPage) { clearTimeout(timeoutNextPage); console.log("⛔ ยกเลิกการเปลี่ยนหน้าแล้ว"); } };

//Session Storage

const clearSessionStorage = () => sessionStorage.clear();

const setCardData = (card) => sessionStorage.setItem("cardData", JSON.stringify(card));
const getCardData = () => JSON.parse(sessionStorage.getItem("cardData") ?? null);
const removeCardData = () => sessionStorage.removeItem("cardData");

const setCapture = (d) => sessionStorage.setItem("capture", d);
const getCapture = () => sessionStorage.getItem("capture");

const setConsent = () => sessionStorage.setItem("hasConsent", true);
const getConsent = () => sessionStorage.getItem("hasConsent");

const setCountTimer = (d) => sessionStorage.setItem("countTimer", d);
const getCountTimer = () => sessionStorage.getItem("countTimer");

const setCustomForm = (c) => sessionStorage.setItem("CustomForm", c);
const getCustomForm = () => sessionStorage.getItem("CustomForm")

const setIntegrateNdpp = (c) => sessionStorage.setItem("IntegrateNdpp", JSON.stringify(c));
const getIntegrateNdpp = () => JSON.parse(sessionStorage.getItem("IntegrateNdpp") ?? null);
const removeIntegrateNdpp = () => sessionStorage.removeItem("IntegrateNdpp");

const setCustomData = (customdata) => sessionStorage.setItem("CustomData", JSON.stringify(customdata));
const getCustomData = () => sessionStorage.getItem("CustomData")

const setReturningUser = (data) => sessionStorage.setItem("ReturningUser", JSON.stringify(data));
const getReturningUser = () => JSON.parse(sessionStorage.getItem("ReturningUser") ?? null);
const removeReturningUser = () => sessionStorage.removeItem("ReturningUser");

//Local Storage
window.SetKioskCode = (code) => localStorage.setItem('selectedKioskCode', code);
window.GetKioskCode = () => localStorage.getItem('selectedKioskCode');

window.SetLoginDetail = (data) => localStorage.setItem('LoginDetail', JSON.stringify(data));
window.GetLoginDetail = () => JSON.parse(localStorage.getItem("LoginDetail") ?? null);

window.getKioskHomeDelaySec = () => localStorage.getItem("kioskHomeDelaySec");
window.getKioskWaitBrokenCardSec = () => localStorage.getItem("kioskWaitBrokenCardSec");
window.getKioskReadStepSec = () => localStorage.getItem("kioskReadStepSec");
window.getKioskReadStepScanSec = () => localStorage.getItem("kioskReadStepScanSec");