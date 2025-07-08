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

window.GetKioskCode = () => localStorage.getItem('selectedKioskCode');

const setCardData = (card) => sessionStorage.setItem("cardData", JSON.stringify(card));
const getCardData = () => JSON.parse(sessionStorage.getItem("cardData") ?? null);
const removeCardData = () => sessionStorage.removeItem("cardData");

const setCapture = (d) => sessionStorage.setItem("capture", d);
const getCapture = () => sessionStorage.getItem("capture");

const setConsent = () => sessionStorage.setItem("hasConsent", true);
const getConsent = () => sessionStorage.getItem("hasConsent");

const clearSessionStorage = () => sessionStorage.clear();
