document.addEventListener("DOMContentLoaded", function () {
    const audio = document.getElementById("click-sound");
    const cardLink = document.getElementById("cardLink");

    if (cardLink && audio) {
        cardLink.addEventListener("click", function (e) {
            e.preventDefault();
            audio.currentTime = 0;
            audio.play().then(() => {
                setTimeout(() => {
                    window.location.href = cardLink.href;
                }, 300);
            }).catch(err => {
                console.warn("Sound error:", err);
                window.location.href = cardLink.href;
            });
        });
    }

    document.body.addEventListener("click", function (e) {
        if (e.target.closest("#cardLink")) return;

        if (audio) {
            audio.currentTime = 0;
            audio.play().catch(err => console.warn("Sound error:", err));
        }
    });
});

window.Step1 = {
    init: () => {
        console.log("Step 1 welcome");
        clearSessionStorage();
    }
};

/*window.Step2 = {
    init: () => {
        console.log("Step 2 read me");
        var read_sec = getKioskReadStepSec(); //from variable [kiosk_read_step_sec]
        next_page("/Step/Step3", read_sec);
        setCountTimer(0);
    }
};*/

window.Step3 = {
    init: async () => {
        console.log("Step 3 read consent and check consent");

        const checkbox = document.getElementById('acceptCheckbox');
        const button = document.getElementById('submitButton');

        if (checkbox) {
            checkbox.addEventListener('change', () => {
                button.disabled = !checkbox.checked;
            });
        }

        if (button) {
            button.addEventListener("click", () => {
                setConsent();
                if (getCardData() == null) {
                    next_page("/Step/Step4");
                } else {
                    next_page("/Step/Step5");
                }
            });
        }

        // Scroll animation
        const el = document.querySelector('.interac_icon_scroll');
        const wrapper = document.querySelector('.scroll-anime');
        if (el && wrapper) {
            let count = 0;
            el.addEventListener('animationiteration', () => {
                count++;
                if (count === 3) wrapper.style.display = 'none';
            });
        }

        // ดึง Privacy Notice จาก NDPP
        const loading = document.getElementById("privacy-notice-loading");
        const contentDiv = document.getElementById("privacy-notice-content");
        const fallback = document.getElementById("privacy-notice-fallback");
        try {
            const res = await fetch('/api/KioskApi/GetPrivacyNotice');
            if (res.ok) {
                const data = await res.json();
                if (data.content) {
                    const titleEl = document.getElementById("privacy-notice-title");
                    const bodyEl = document.getElementById("privacy-notice-body");
                    if (titleEl) titleEl.textContent = data.name || "Privacy Notice";
                    if (bodyEl) bodyEl.innerHTML = data.content;
                    if (contentDiv) contentDiv.style.display = "block";
                } else {
                    if (fallback) fallback.style.display = "block";
                }
            } else {
                if (fallback) fallback.style.display = "block";
            }
        } catch (err) {
            console.error("GetPrivacyNotice error:", err);
            if (fallback) fallback.style.display = "block";
        } finally {
            if (loading) loading.style.display = "none";
            if (checkbox) checkbox.disabled = false;
            const label = document.getElementById("acceptCheckboxLabel");
            if (label) { label.style.pointerEvents = "auto"; label.style.opacity = "1"; }
        }
    }
};

window.Step4 = {
    init: () => {
        console.log("Step 4 connected =>", window.GetKioskCode());

        // ❌ เอา setTimeout แบบเก่าออกไปได้เลย เพราะเราจะไปคุมเวลาที่ตัวนับถอยหลังแทน
        /* setTimeout(() => {
            var alert_card = document.getElementById("alert-notfound-card");
            if (alert_card != null)
                alert_card.style.setProperty("display", "block", "important");
        }, 15_000); 
        */

        const audio = document.getElementById("scan_card");
        if (audio) {
            audio.currentTime = 0;
            audio.play().catch(err => console.warn("Sound error:", err));
        }

        Step4.start_count_down();
    },

    start_count_down: () => {
        let timeLeft = 30;
        const totalTime = 30;
        const progressBar = document.getElementById("progressBar");
        const countdownText = document.getElementById("countdownText");

        const alert_card = document.getElementById("alert-notfound-card");

        if (window.step4Timer) clearInterval(window.step4Timer);

        window.step4Timer = setInterval(() => {
            timeLeft--;

            if (countdownText) countdownText.innerText = timeLeft;

            if (progressBar) {
                const widthPercentage = (timeLeft / totalTime) * 100;
                progressBar.style.width = widthPercentage + "%";

                if (timeLeft <= 15 && timeLeft > 5) {
                    progressBar.classList.add("warning");
                    if (countdownText) countdownText.style.color = "#f59e0b";

                    if (alert_card) {
                        alert_card.classList.remove("d-none");
                        alert_card.style.setProperty("display", "block", "important"); 
                        alert_card.style.color = "#f59e0b";
                    }

                } else if (timeLeft <= 5) {
                    progressBar.classList.add("danger");
                    if (countdownText) countdownText.style.color = "#ef4444";

                    if (alert_card) {
                        alert_card.style.color = "#ef4444";
                        alert_card.style.fontWeight = "bold";
                    }
                }
            }

            if (timeLeft <= 0) {
                clearInterval(window.step4Timer);
                console.log("Step 4: Timeout, returning to Step 1");
                next_page("/Step/Step1");
            }
        }, 1000);
    }
};

window.Step5 = {
    init: () => {
        console.log("Step 5: Card found");
        setTimeout(() => {
            Step5.check();
        }, 10_000);
    },
    check: async () => {
        var _card = getCardData();
        var state = 1;
        if (_card == null) state = 2;
        else if (_card.expried) state = 3;

        switch (state) {
            case 1:
                // Check returning user from local DB
                let isReturning = false;
                try {
                    const idcard = _card.citizenID ?? "";
                    if (idcard) {
                        const res = await fetch(`/api/KioskApi/CheckReturningUser?idcard=${encodeURIComponent(idcard)}`);
                        if (res.ok) {
                            const data = await res.json();
                            if (data.isReturning) {
                                setReturningUser(data);
                                isReturning = true;
                                console.log("Returning user detected:", data);
                            } else {
                                removeReturningUser();
                            }
                        }
                    }
                } catch (err) {
                    console.error("CheckReturningUser error:", err);
                    removeReturningUser();
                }

                // Returning user → preload NDPP data (ปกติโหลดใน Step12 ที่จะถูกข้าม)
                if (isReturning) {
                    try {
                        const ndppRes = await fetch('/api/KioskApi/GetIntegrateNdpp', { headers: { "Content-Type": "application/json" } });
                        if (ndppRes.ok) setIntegrateNdpp(await ndppRes.json());
                    } catch (err) {
                        console.error("Preload NDPP error:", err);
                    }
                }

                next_page("/Step/Step8", 1);
                break;
            case 2:
                next_page("/Step/Step6", 1);
                break;
            case 3:
                next_page("/Step/Step7", 1);
                break;
            default:
                console.warn("Step4.check: Unhandled state", state);
        }
    }
};

window.Step6 = {
    init: () => {
        console.log("Step 6: Broken ID card");
        var _btn = document.querySelector(".retry-button");
        if (_btn != null) _btn.addEventListener('click', () => next_page("/Step/Step4"));

        var _btn_fail = document.querySelector(".cancel-button-fail");
        if (_btn_fail != null) _btn_fail.addEventListener('click', () => next_page("/Step/Step1"));

        Step6.start_count_down();
    },
    start_count_down: () => {
        let countdown = getKioskWaitBrokenCardSec(); //from variable [kiosk_wait_broken_card_sec]
        const countdownElement = document.querySelector(".step6.countdown");
        if (countdownElement) {
            const timer = setInterval(() => {
                countdown--;
                countdownElement.textContent = countdown;

                if (countdown <= 0) {
                    clearInterval(timer);
                    countdownElement.textContent = '0';
                    next_page("/Step/Step1");
                }
            }, 1000);
        }
    }
};

window.Step7 = {
    init: () => {
        console.log("Step 7: Retry connect card");
        const cancelBtn = document.querySelector(".cancel-button-fail.step7");
        if (cancelBtn != null) cancelBtn.addEventListener('click', () => next_page("/Step/Step1"));
    }
};

/*window.Step8 = {
    init: () => {
        console.log("Step 8: Read card successful");
        const returning = getReturningUser();
        if (returning && returning.isReturning) {
            console.log("Returning user — skip face capture, go to Step17");
            next_page("/Step/Step17", 3);
        } else {
            next_page("/Step/Step9", 5);
        }
    }
};

window.Step9 = {
    init: () => {
        console.log("Step 9: Recommend scanning");
        var read_sec = getKioskReadStepScanSec(); //from variable [kiosk_read_step_scan_sec]
        next_page("/Step/Step10", read_sec);
    }
};*/

window.Step10 = {
    init: () => {
        console.log("Step 10: Face scanning");
        var scan_again = document.querySelector(".scan-again");
        if (scan_again) {
            scan_again.addEventListener("click", function (e) {
                next_page("/Step/Step10");
            });
        }

        var submit_scan = document.querySelector(".submit-scan");
        if (submit_scan) {
            submit_scan.addEventListener("click", function (e) {
                next_page("/Step/Step11");
            });
        }
    },
    capture_success: () => {
        //next_page("/Step/Step11", 1.5);
    }
};

window.Step11 = {
    init: () => {
        console.log("Step 11: Scanning successful");
        next_page("/Step/Step12", 5);
    }
};

window.Step12 = {
    init: () => {
        console.log("Step 12: Editing card data and confirmation");
        //get customform
        try {
            const response = fetch('/api/KioskApi/GetCustomForm', {
                method: 'GET',
                headers: { "Content-Type": "application/json", }
            }).then(response => {
                if (!response.ok) throw new Error("เกิดข้อผิดพลาด: " + response.status);
                return response.json();
            }).then(data => {
                setCustomForm(data);
            })
        } catch (error) {
            alert(error.message);
        }
        //get integrate ndpp
        try {
            const response = fetch('/api/KioskApi/GetIntegrateNdpp', {
                method: 'GET',
                headers: { "Content-Type": "application/json", }
            }).then(response => {
                if (!response.ok) throw new Error("เกิดข้อผิดพลาด: " + response.status);
                return response.json();
            }).then(data => {
                setIntegrateNdpp(data);
            })
        } catch (error) {
            alert(error.message);
        }
    }
};

window.Step14 = {
    init: () => {
        console.log("Step 14: Customfield");
        const getCustomfield = sessionStorage.getItem("CustomField");
        console.log(getCustomfield);
    },
    save_consent: async () => {
        let cardData = getCardData();
        let CustomData = getCustomData();
        let capture = getCapture();
        let resizeCapture = await window.resizeImage(capture, 300);

        cardData.KioskCode = GetKioskCode();
        cardData.face_capture = resizeCapture;

        const encrypUpdatedData = cardData.updatedData ? encrypt(cardData.updatedData) : "";
        delete cardData.updatedData;
        const encrypCustomData = CustomData ? encrypt(CustomData) : "";
        const encrypCardData = encrypt(cardData);

        try {
            const response = await fetch('/api/KioskApi/SaveNationalCardData', {
                method: 'POST',
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({
                    EncrypString: encrypCardData,
                    EncrypUpdatedData: encrypUpdatedData,
                    EncrypCustomDataData: encrypCustomData,
                })
            });

            let result = {};
            try { result = await response.json(); } catch { }
            if (!response.ok) {
                throw new Error(result?.message ?? "บันทึกไม่สำเร็จ");
            } else {
                cardData.photo_path = result.photo_path ?? "";
                cardData.face_capture_path = result.face_capture_path ?? "";
                setCardData(cardData);
                next_page();
            }
        } catch (error) {
            alert(error.message);
        }
    }
};


window.Step17 = {
    init: async () => {
        const cardData = getCardData();
        const returningUser = getReturningUser();

        let getIntegrateNdppData = await getIntegrateNdpp();

        if (!getIntegrateNdppData?.length) { next_page(); return; }

        // ดึง consent เดิม (ถ้าเคย submit มาก่อน)
        let previousConsent = null;
        try {
            const citizenId = cardData.citizenID ?? "";
            const kioskCode = GetKioskCode();
            if (citizenId && kioskCode) {
                const res = await fetch(`/api/KioskApi/GetNdppConsented?citizenId=${encodeURIComponent(citizenId)}&kioskCode=${encodeURIComponent(kioskCode)}`);
                if (res.ok) {
                    const text = await res.text();
                    previousConsent = text ? JSON.parse(text) : null;
                    if (previousConsent?.purposeOptionDetail) {
                        previousConsent._parsed = JSON.parse(previousConsent.purposeOptionDetail);
                    }
                }
            }
        } catch (err) {
            console.error("GetNdppConsented error:", err);
        }
        Step17._previousConsent = previousConsent;

        if (returningUser && returningUser.isReturning) {
            console.log("Returning user — show consent form for editing");
            removeReturningUser();
        }

        // แสดงหน้าเลือก/กรอก consent
        const step17Content = document.getElementById("step17-content");
        if (step17Content) step17Content.style.display = "";

        // ปุ่มแก้ไขข้อมูล → กลับไปหน้า Step12
        const btnEditInfo = document.getElementById("btn-edit-info");
        if (btnEditInfo) {
            btnEditInfo.addEventListener("click", () => {
                next_page("/Step/Step12");
            });
        }

        const submitConsent = document.getElementById("submit-consent");
        if (submitConsent) submitConsent.addEventListener("click", async (e) => {
            e.preventDefault();
            const firstname = document.getElementById("firstname").value.trim();
            const lastname = document.getElementById("lastname").value.trim();
            const email = document.getElementById("email").value.trim();

            const selectedPurposes = Array.from(
                document.querySelectorAll("#ndpp-form input[name='purpose']:checked")
            ).map(input => parseInt(input.value));

            const purposeOptionDetail = Array.from(
                document.querySelectorAll("#ndpp-form input[name='purpose']")
            ).map(input => ({
                PurposeNameId: input.value,
                PurposeName: input.nextElementSibling?.textContent?.trim() ?? "",
                PurposeChecked: input.checked
            }));

            const payload = {
                Firstname: firstname || cardData.thaiPersonalInfo.firstName,
                Lastname: lastname || cardData.thaiPersonalInfo.lastName,
                Email: email,
                IntegrateNdppId: Step17._ndppId,
                IntegrateUrl: Step17._url,
                PurposeOption: selectedPurposes,
                PurposeOptionDetail: purposeOptionDetail,
                NdppFormData: JSON.stringify(Step17._ndppFormData),
                citizenID: cardData.citizenID ?? "",
                fullNameTH: cardData.fullNameTH ?? "",
                fullNameEN: cardData.fullNameEN ?? "",
                photo_path: cardData.photo_path ?? "",
                face_capture_path: cardData.face_capture_path ?? "",
                KioskCode: GetKioskCode()
            };
            try {
                const response = await fetch("/api/KioskApi/SubmitIntegrateNdpp", {
                    method: "POST",
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify({ EncryptedINDPPString: encrypt(payload) })
                });
                if (!response.ok) throw new Error("ส่งข้อมูลไม่สำเร็จ " + response.status);
                await response.json();
                window.location.href = "/Step/StepEnd";
            } catch (err) {
                console.error(err);
                alert("เกิดข้อผิดพลาดในการบันทึก");
            }
        });

        // ถ้ามี 1 รายการ → เปิด consent form เลย
        if (getIntegrateNdppData.length === 1) {
            const item = getIntegrateNdppData[0];
            Step17._ndppId = item.id;
            Step17._url = item.ndppPreferenceUrl;

            const encrypCardData = encrypt({
                Firstname: cardData.thaiPersonalInfo.firstName,
                Lastname: cardData.thaiPersonalInfo.lastName,
                IntegrateNdppId: item.id
            });

            try {
                const response = await fetch('/api/KioskApi/GetIntegrateNdppForm', {
                    method: 'POST',
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify({ EncryptedINDPPString: encrypCardData })
                });
                if (response.ok) {
                    const data = await response.json();
                    if (data) {
                        Step17._ndppFormData = data;
                        Step17.showNdppForm(data, cardData);
                        return;
                    }
                }
            } catch (err) {
                console.error(err);
            }
        }

        // หลายรายการ → สร้าง card list
        const container = document.getElementById("ndpp-container");
        container.innerHTML = "";
        getIntegrateNdppData.forEach(item => {
            const col = document.createElement("div");
            col.className = "col-12 col-sm-6 col-lg-4";
            const imgSrc = item.serviceImage ? `data:image/png;base64,${item.serviceImage}` : '';
            col.innerHTML = `
                <div class="card h-100 shadow-sm">
                    ${imgSrc ? `<img src="${imgSrc}" class="card-img-top" alt="${item.serviceName}">` : ''}
                    <div class="card-body d-flex flex-column">
                        <h5 class="card-title">${item.serviceName}</h5>
                        <p class="card-text text-truncate" style="max-height:3.6em;">${item.serviceDescription}</p>
                        <p class="mb-1"><small>เริ่ม: ${new Date(item.serviceStartDate).toLocaleString()}</small></p>
                        <p class="mb-2"><small>สิ้นสุด: ${new Date(item.serviceStopDate).toLocaleString()}</small></p>
                        <button class="btn btn-primary mt-auto btn-open"
                                data-url="${item.ndppPreferenceUrl}"
                                data-id="${item.id}">เปิดดู</button>
                    </div>
                </div>`;
            container.appendChild(col);
        });

        // กดเลือก service
        container.addEventListener("click", async (e) => {
            if (!e.target.classList.contains("btn-open")) return;
            Step17._ndppId = e.target.getAttribute("data-id");
            Step17._url = e.target.getAttribute("data-url");

            const encrypCardData = encrypt({
                Firstname: cardData.thaiPersonalInfo.firstName,
                Lastname: cardData.thaiPersonalInfo.lastName,
                IntegrateNdppId: Step17._ndppId
            });
            try {
                const response = await fetch('/api/KioskApi/GetIntegrateNdppForm', {
                    method: 'POST',
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify({ EncryptedINDPPString: encrypCardData })
                });
                if (!response.ok) throw new Error("เกิดข้อผิดพลาด: " + response.status);
                const data = await response.json();
                if (data) {
                    Step17._ndppFormData = data;
                    Step17.showNdppForm(data, cardData);
                } else {
                    alert("ไม่พบ URL ของ NDPP");
                }
            } catch (err) {
                console.error(err);
                alert("โหลดข้อมูลไม่สำเร็จ");
            }
        });

    },

    _ndppId: 0,
    _url: "",
    _ndppFormData: null,

    showNdppForm: (data, cardData) => {
        const container = document.getElementById("ndpp-form-container");
        const title = document.getElementById("activity-title");
        const activityContent = document.getElementById("activity-content");

        title.textContent = data.ActivityNameTh || data.ServiceNameTh || "NDPP Form";

        const replacedContent = data.content
            .replace("{PurposeOption}", '<div id="purpose-placeholder"></div>')
            .replace("{SubPurposeOption}", '<div id="sub-purpose-placeholder"></div>');
        activityContent.innerHTML = replacedContent;

        const placeholder = document.getElementById("purpose-placeholder");
        const subplaceholder = document.getElementById("sub-purpose-placeholder");

        // ดึง consent เดิมมา prefill
        const prev = Step17._previousConsent?._parsed ?? [];

        data.purpose_option.forEach(purpose => {
            const prevItem = prev.find(p => String(p.PurposeNameId) === String(purpose.purpose_id));
            const isChecked = prevItem ? prevItem.PurposeChecked : purpose.selected;

            const div = document.createElement("div");
            div.classList.add("form-check");
            div.innerHTML = `
                <input class="form-check-input" type="checkbox"
                       id="purpose-${purpose.purpose_id}"
                       name="purpose"
                       value="${purpose.purpose_id}"
                       ${isChecked ? "checked" : ""}
                       ${purpose.is_required ? "required" : ""}>
                <label class="form-check-label" for="purpose-${purpose.purpose_id}">
                    ${purpose.purpose_th || purpose.purpose_en}
                </label>`;
            if (purpose.purpose_type == "Standard") {
                placeholder.appendChild(div);
            } else {
                subplaceholder.appendChild(div);
            }
        });

        const prevEmail = Step17._previousConsent?.email ?? "";
        document.getElementById("firstname").value = cardData.thaiPersonalInfo.firstName || "";
        document.getElementById("lastname").value = cardData.thaiPersonalInfo.lastName || "";
        document.getElementById("email").value = prevEmail;

        container.style.display = "block";
        document.getElementById("ndpp-container").style.display = "none";
    }
};



window.StepEnd = {
    init: () => {
        console.log("StepEnd: Success (without card)");
        let counter = getKioskHomeDelaySec(); //from variable [kiosk_home_delay_sec];
        const countdownEl = document.getElementById("countdown-end");

        const interval = setInterval(() => {
            counter--;
            if (countdownEl) {
                countdownEl.textContent = counter;
            }

            if (counter <= 0) {
                clearInterval(interval);
                next_page("/Step/Step1");
            }
        }, 1000);
    }
};

window.onCardInserted = () => {
    if (!getConsent()) next_page("/Step/Step3", 0.5);
    else next_page("/Step/Step5", 0.5);
}

window.withoutCard = () => {
    if (location.pathname == "/Step/Step6") {
    } else if (location.pathname == "/Step/StepEnd") {
        next_page("/Step/Step1");
    } else if (location.pathname != "/Step/Step1") {
        showCountdownAndRedirect(10);
    }
}

let countdownInterval;
function showCountdownAndRedirect(seconds = 5) {
    cancelNextPage();

    let countdown = seconds;
    document.getElementById('countdown').textContent = countdown;

    // แสดง modal
    const modal = new bootstrap.Modal(document.getElementById('cardRemovedModal'));
    modal.show();

    // เริ่มนับถอยหลัง
    countdownInterval = setInterval(() => {
        countdown--;
        document.getElementById('countdown').textContent = countdown;

        if (countdown <= 0) {
            clearInterval(countdownInterval);
            next_page("/Step/Step1");
        }
    }, 1000);
}

(function () {
    const currentPath = window.location.pathname;
    const match = currentPath.match(/^\/Step\/Step(\d+)$/);
    const matchEnd = currentPath === "/Step/StepEnd";

    if (match) {
        const stepNum = match[1];
        const stepHandler = window[`Step${stepNum}`];

        if (stepHandler?.init) {
            stepHandler.init();
        } else {
            console.warn(`Step${stepNum}.init() not found`);
        }
    } else if (matchEnd && window.StepEnd?.init) {
        window.StepEnd.init();
    }

    document.addEventListener("click", function (e) {
        const touch = document.createElement("div");
        touch.classList.add("touch-effect");
        touch.style.left = `${e.clientX}px`;
        touch.style.top = `${e.clientY}px`;

        document.body.appendChild(touch);
        setTimeout(() => { touch.remove(); }, 500);
    });

    const timerElement = document.getElementById("timer");
    if (timerElement) {
        if (location.pathname == "/Step/Step1") {
            setCountTimer(0);
            timerElement.textContent = 0;
        } else {
            // ⏱ ตัวจับเวลา
            const timerInterval = setInterval(() => {
                var sec = (getCountTimer() ?? 0);
                sec++;
                setCountTimer(sec);
                timerElement.textContent = sec;
            }, 1000);
        }
    }

    const cTimer = document.querySelector(".timer");
    if (cTimer) {
        if (location.pathname.startsWith("/Step/Step")) {
            cTimer.style.setProperty("display", "block", "important");
        } else {
            cTimer.style.setProperty("display", "none", "important");
        }
    }
})();