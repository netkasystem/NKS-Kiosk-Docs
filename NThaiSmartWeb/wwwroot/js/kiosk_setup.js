downloadFileSetup = function (code) {
    DownloadFile({ api: `/api/KioskApi/DownloadFile?fileCode=${code}` });
}

function openZoneModal() {
    const modal = document.getElementById("zoneModal");
    modal.setAttribute("aria-hidden", "false");
}

function closeZoneModal() {
    const modal = document.getElementById("zoneModal");
    modal.setAttribute("aria-hidden", "true");
}

function downloadZone(zone) {
    console.log("ดาวน์โหลด Zone", zone);
    downloadFileSetup(`zone-${zone}-file`);
}

function openZoneManualModal() {
    // ถ้ามี modal แยกสำหรับคู่มือ ตรงนี้เรียกเปิดได้
    alert("เปิดคู่มือการติดตั้ง (ถ้ายังไม่มี ให้เพิ่ม modal หรือเปลี่ยน logic ตรงนี้)");
}
