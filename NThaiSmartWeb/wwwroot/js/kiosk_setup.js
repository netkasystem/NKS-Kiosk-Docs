downloadFileSetup = function (code) {
    DownloadFile({ api: `/api/KioskApi/DownloadFile?fileCode=${code}` });
}