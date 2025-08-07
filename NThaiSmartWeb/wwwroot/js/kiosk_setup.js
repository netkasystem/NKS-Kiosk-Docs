angular.module('main')
    .controller('KioskSetupController', ['$scope', '$timeout', function ($scope, $timeout) {
        $scope.isZoneModalOpen = true;
        $scope.isKioskModalOpen = false;

        $scope.filter = {}; // Ensure exists
        $scope.KioskID = null;
        $scope.Regions = [
            { RegionID: 1, RegionDescription: "พื้นที่ กรุงเทพฯ และปริมณฑล", Title: "Zone 1" },
            { RegionID: 2, RegionDescription: " ภาคตะวันออกและภาคกลาง", Title: "Zone 2" },
            { RegionID: 3, RegionDescription: " ภาคเหนือ (เช่น เชียงใหม่, ลำพูน)", Title: "Zone 3" },
            { RegionID: 4, RegionDescription: " ภาคใต้ (เช่น ภูเก็ต, สงขลา)", Title: "Zone 4" },
            { RegionID: 5, RegionDescription: " ภาคตะวันออกเฉียงเหนือ (เช่น ขอนแก่น, อุดรธานี)", Title: "Zone 5" }
        ];

        $timeout(() => {
            //GetRegion();
        });

        function GetRegion() {
            ajaxCommon.post("/api/Select2Api/SearchData",
                { Select2Name: "kiosk_region" },
                (res) => {
                    $scope.Regions = [];
                    console.log("get =>", res);
                    if (res?.items?.length) {
                        $scope.Regions = [];
                    }
                },
                (res) => { }
            );
        }

        $scope.openKioskModal = function (regionId) {
            $scope.filter.RegionId = regionId;
            $scope.KioskID = null;
            //$('#kioskModal1').modal('show');

           // Download file ตาม Login user แบบแบ่ง Region ไปก่อน
            $scope.downloadFileSetup(`setup-kiosk-config-region-${$scope.filter.RegionId}`);

        };

        $scope.closeKioskModal = function () {
            $scope.isKioskModalOpen = false;
        };

        $scope.downloadSelectedKiosk = function () {
            if (!$scope.KioskID) {
                alert('กรุณาเลือก Kiosk');
                return;
            }

            // TODO: ทำสิ่งที่ต้องการ เช่น ดาวน์โหลดไฟล์
            console.log('Download Kiosk:', $scope.KioskID);
            $scope.downloadFileSetup(`setup-kiosk-config-region-${$scope.filter.RegionId}`, $scope.KioskID);
            // ปิด modal
            $scope.closeKioskModal();
        };

        $scope.downloadFileSetup = function (filecode, kioskid = 0) {
            const api_load = `/api/KioskApi/DownloadFile?fileCode=${filecode}`;

            if (kioskid) api_load += `?KioskID=${kioskid}`;

            DownloadFile({ api: api_load });
        }

        $scope.openZoneModal = function () {
            const modal = document.getElementById("zoneModal");
            modal.setAttribute("aria-hidden", "false");
        }

        $scope.closeZoneModal = function () {
            const modal = document.getElementById("zoneModal");
            modal.setAttribute("aria-hidden", "true");
        }

        $scope.downloadZone = function (zone) {
            console.log("ดาวน์โหลด Zone", zone);
            downloadFileSetup(`zone-${zone}-file`);
        }

        $scope.openZoneManualModal = function () {
            // ถ้ามี modal แยกสำหรับคู่มือ ตรงนี้เรียกเปิดได้
            alert("เปิดคู่มือการติดตั้ง (ถ้ายังไม่มี ให้เพิ่ม modal หรือเปลี่ยน logic ตรงนี้)");
        }

        $scope.loadConfigByRegion = function (region_id) {
            if (region_id) {
                downloadFileSetup(`setup-kioskconfig-region${region_id}`);
            }
        }
    }]);