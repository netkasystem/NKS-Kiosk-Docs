const Step4 = {
    init: () => {
        console.log("Step 4 connected =>", window.GetKioskCode());
    },
    check: (state) => {
        setTimeout(() => {
            switch (state) {
                case 1:
                    window.location.href = "/Step/Step5";
                    break;
                case 2:
                    window.location.href = "/Step/Step6";
                    break;
                case 3:
                    window.location.href = "/Step/Step7";
                    break;
                default:
                    console.warn("Step4.check: Unhandled state", state);
            }
        }, 1000);
    }
};

const Step5 = {
    init: () => {
        console.log("Step 5: Card found");
        setTimeout(() => {
            window.location.href = "/Step/Step8";
        }, 1000);
    }
};

const Step9 = {
    init: () => {
        console.log("Step 9: Recommend scanning");
        setTimeout(() => {
            window.location.href = "/Step/Step10";
        }, 10_000); // 10 seconds
    }
};

const Step10 = {
    init: () => {
        console.log("Step 10: Face scanning");
        setTimeout(() => {
            window.location.href = "/Step/Step11";
        }, 5_000); // 5 seconds
    }
};

const Step11 = {
    init: () => {
        console.log("Step 11: Scanning successful");
        setTimeout(() => {
            window.location.href = "/Step/Step12";
        }, 5_000);
    }
};

const Step12 = {
    init: () => {
        console.log("Step 12: Editing card data and confirmation");
        // ไม่มี redirect รอ user action
    }
};

const Step13 = {
    init: () => {
        console.log("Step 13: Success (without card)");
        setTimeout(() => {
            window.location.href = "/Step/Step1";
        }, 5_000);
    },
    withoutCard: () => {
        window.location.href = "/Step/Step1";
    }
};
