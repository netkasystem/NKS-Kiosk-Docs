const next_page = (href, time_sec = 0) => {
    setTimeout(() => { window.location.href = href; }, time_sec * 1000);
}

window.Step3 = {
    init: () => {
        console.log("Step 3 read consent and check consent");

        document.getElementById("submitButton").addEventListener("click", () => {
            const checkbox = document.getElementById('acceptCheckbox');
            if (checkbox.checked) {
                setConsent();
                if (getCardData() == null) {
                    next_page("/Step/Step4", 1.5);
                } else {
                    next_page("/Step/Step5", 1.5);
                }
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
        next_page("/Step/Step11", 3);
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
    }
};

window.Step13 = {
    init: () => {
        console.log("Step 13: Success (without card)");
        next_page("/Step/Step1", 8);
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
