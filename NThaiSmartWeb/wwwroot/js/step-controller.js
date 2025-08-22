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

window.Step2 = {
    init: () => {
        console.log("Step 2 read me");
        var read_sec = getKioskReadStepSec(); //from variable [kiosk_read_step_sec]
        next_page("/Step/Step3", read_sec);
        setCountTimer(0);
    }
};

window.Step3 = {
    init: () => {
        console.log("Step 3 read consent and check consent");

        const checkbox = document.getElementById('acceptCheckbox');
        const button = document.getElementById('submitButton');

        checkbox.addEventListener('change', () => {
            button.disabled = !checkbox.checked;
        });

        button.addEventListener("click", () => {
            setConsent();
            if (getCardData() == null) {
                next_page("/Step/Step4");
            } else {
                next_page("/Step/Step5");
            }
        });
    }
};

window.Step4 = {
    init: () => {
        console.log("Step 4 connected =>", window.GetKioskCode());
        setTimeout(() => {
            var alert_card = document.getElementById("alert-notfound-card");
            if (alert_card != null)
                alert_card.style.setProperty("display", "block", "important");
        }, 5_000);
    }
};

window.Step5 = {
    init: () => {
        console.log("Step 5: Card found");
        setTimeout(() => {
            Step5.check();
        }, 1000);
    },
    check: () => {
        var _card = getCardData();
        var state = 1;
        if (_card == null) state = 2;
        else if (_card.expried) state = 3;

        switch (state) {
            case 1:
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

window.Step8 = {
    init: () => {
        console.log("Step 8: Read card successful");
        next_page("/Step/Step9", 5);
    }
};

window.Step9 = {
    init: () => {
        console.log("Step 9: Recommend scanning");
        var read_sec = getKioskReadStepScanSec(); //from variable [kiosk_read_step_scan_sec]
        next_page("/Step/Step10", read_sec);
    }
};

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

window.Step13 = {
    init: () => {
        console.log("Step 13: Success (without card)");
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

            const message = await response.text();

            if (!response.ok) {
                throw new Error(message);
            } else {
                next_page("/Step/Step13", 1);
            }
        } catch (error) {
            alert(error.message);
        }
    }
};

window.Step15 = {
    init: () => {
         
    }
};

window.onCardInserted = () => {
    if (!getConsent()) next_page("/Step/Step3", 0.5);
    else next_page("/Step/Step5", 0.5);
}

window.withoutCard = () => {
    if (location.pathname == "/Step/Step6") {
    } else if (location.pathname == "/Step/Step13") {
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

    if (match) {
        const stepNum = match[1];
        const stepHandler = window[`Step${stepNum}`];

        if (stepHandler?.init) {
            stepHandler.init();
        } else {
            console.warn(`Step${stepNum}.init() not found`);
        }
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