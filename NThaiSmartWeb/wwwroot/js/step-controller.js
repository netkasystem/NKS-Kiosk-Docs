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

window.Step7 = {
    init: () => {
        console.log("Step 7: Retry connect card");
        next_page("/Step/Step7", 1);
    }
};

window.Step8 = {
    init: () => {
        console.log("Step 8: Read card successful");
        next_page("/Step/Step9", 3);
    }
};

window.Step9 = {
    init: () => {
        console.log("Step 9: Recommend scanning");
        next_page("/Step/Step10", 5);
    }
};

window.Step10 = {
    init: () => {
        console.log("Step 10: Face scanning");
    },
    capture_success: () => {
        next_page("/Step/Step11", 1.5);
    }
};

window.Step11 = {
    init: () => {
        console.log("Step 11: Scanning successful");
        next_page("/Step/Step12", 3);
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
    } 
};

window.Step13 = {
    init: () => {
        console.log("Step 13: Success (without card)");
        next_page("/Step/Step1", 8);
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
        let capture = getCapture();
        let resizeCapture = await window.resizeImage(capture, 300);
        let CustomData = getCustomData();

        
        cardData.KioskCode = GetKioskCode();
        cardData.face_capture = resizeCapture;
        cardData.CustomData = CustomData;
        const encrypCardData = encrypt(cardData);

        try {
            const response = await fetch('/api/KioskApi/SaveNationalCardData', {
                method: 'POST',
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ EncrypString: encrypCardData })
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

window.onCardInserted = () => {
    if (!getConsent()) next_page("/Step/Step3", 1.5);
    else next_page("/Step/Step5", 1.5);
}

window.withoutCard = () => {
    clearSessionStorage();
    window.location.href = "/Step/Step1";
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
})();
document.addEventListener("click", function (e) {
    const touch = document.createElement("div");
    touch.classList.add("touch-effect");
    touch.style.left = `${e.clientX}px`;
    touch.style.top = `${e.clientY}px`;

    document.body.appendChild(touch);

    setTimeout(() => {
        touch.remove();
    }, 500); 
});
