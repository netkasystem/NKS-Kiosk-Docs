# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build & Run

```bash
# Run (development)
cd NThaiSmartWeb
dotnet run

# Build only
dotnet build NThaiSmartWeb/NThaiSmartWeb.csproj

# Run via Docker Compose (port 5201)
docker compose up --build
```

The app runs on `http://localhost:5201`. In Development mode the nav bar is always visible for easy step navigation.

## Tech Stack

- **ASP.NET Core 8 MVC** — Razor Views, no Blazor
- **MySQL** (via Pomelo EF Core) — connection string in `appsettings.json`
- **Redis** — session/SignalR backplane (`Microsoft.AspNetCore.DataProtection.StackExchangeRedis`)
- **SignalR** — real-time card reader communication via `CardReaderHub` at `/NThaiSmartHub`
- **face-api.js** — face detection models in `wwwroot/models/`
- **jQuery + Bootstrap 5** — loaded via `_Layout.cshtml`

---

## Step Flow Overview

```
Step1 → Step2 → Step3 → Step4 → Step5 → Step8 → Step9 → Step10 → Step11 → Step12 → [Step14] → [Step17] → [Step18] → StepEnd
                                          ↓ error
                                     Step6 (บัตรเสีย) / Step7 (บัตรหมดอายุ) → Step1
```

## Step Pages

| Step | ชื่อหน้า | คำอธิบาย |
|------|---------|----------|
| **Step1** | หน้าแรก / Welcome | หน้า Landing แตะเพื่อเริ่มยืนยันตัวตน, clear session storage |
| **Step2** | แนะนำขั้นตอน | แสดง 3 ขั้นตอน: สอดบัตร → สแกนหน้า → ยืนยันข้อมูล, auto-advance |
| **Step3** | ข้อตกลงและเงื่อนไข | แสดงเงื่อนไขการใช้บริการ, ต้องกดยอมรับก่อนดำเนินการต่อ |
| **Step4** | รอสอดบัตร | แสดง animation รอสอดบัตรประชาชน, แจ้งเตือนหลัง 5 วินาทีถ้าไม่พบบัตร |
| **Step5** | อ่านข้อมูลบัตร | อ่านข้อมูลจากบัตร → valid→Step8, อ่านไม่ได้→Step6, หมดอายุ→Step7 |
| **Step6** | บัตรเสียหาย/ชำรุด | แจ้ง error บัตรอ่านไม่ได้ พร้อมปุ่มลองใหม่/ยกเลิก, auto-reset กลับ Step1 |
| **Step7** | บัตรหมดอายุ | แจ้ง error บัตรหมดอายุ มีปุ่มยกเลิกกลับ Step1 |
| **Step8** | สแกนบัตรสำเร็จ | แสดงผลสำเร็จ แจ้งอย่าถอดบัตร, auto-advance ไป Step9 |
| **Step9** | คำแนะนำสแกนหน้า | แสดง 3 คำแนะนำ: ยืนตรง, ถอดหน้ากาก, แสงสว่างเพียงพอ |
| **Step10** | สแกนใบหน้า | กล้อง live + face detection, ถ่ายภาพ + ปุ่มถ่ายใหม่/ยืนยัน |
| **Step11** | สแกนหน้าสำเร็จ | แสดงรูปที่ถ่ายได้ พร้อมปุ่มยืนยัน, auto-advance ไป Step12 |
| **Step12** | ตรวจสอบข้อมูล | แสดงข้อมูลบัตร (mask/unmask), แก้ไขได้, มี custom form → Step14, ไม่มี → save + next |
| **Step14** | แบบฟอร์มเพิ่มเติม | Dynamic form จาก API (text, textarea, select), submit → save_consent → next_page() |
| **Step16** | (ว่าง/สำรอง) | ยังไม่มี content |
| **Step17** | NDPP Consent (ส่วนกลาง) | แสดงรายการบริการ NDPP, เลือก → กรอกฟอร์ม → submit → StepEnd, ถ้าไม่มีข้อมูลจะข้ามไปเลย |
| **Step18** | NDPP Consent (ตาม Kiosk) | Consent form เฉพาะ Kiosk, fetch ผ่าน proxy, submit → StepEnd, ถ้าไม่มีข้อมูลจะข้ามไปเลย |
| **StepEnd** | จบกระบวนการ | แสดง "ขอบคุณ" + countdown ดึงบัตรออก → auto-reset กลับ Step1 |

> Step 13, 15 ถูกลบออกแล้ว — ระบบ `next_page()` จะข้ามเลขที่ไม่มีอัตโนมัติ

## Conditional Steps

- **Step14** — แสดงเมื่อมี Custom Form config (เช็คจาก `getCustomForm()`)
- **Step17** — แสดงเมื่อมีข้อมูล NDPP integrate ส่วนกลาง (เช็คจาก `getIntegrateNdpp()`)
- **Step18** — แสดงเมื่อมีข้อมูล NDPP integrate เฉพาะ Kiosk (เช็คจาก `getIntegrateNdppByKiosk()`)
- Step17/18 ซ่อน content ไว้ก่อน (`display:none`) ถ้าไม่มีข้อมูลจะ `next_page()` ข้ามไปโดยไม่กระพริบ

---

## Key Files

| ไฟล์ | คำอธิบาย |
|------|----------|
| `NThaiSmartWeb/Controllers/StepController.cs` | Controller ที่ register action ของแต่ละ Step |
| `NThaiSmartWeb/wwwroot/js/step-controller.js` | JS logic ของทุก Step (init, save, navigation) |
| `NThaiSmartWeb/wwwroot/js/common-script.js` | Utility functions: encrypt/decrypt, session storage, `next_page()`, `findNextStep()`, i18n |
| `NThaiSmartWeb/wwwroot/js/common-ajax.js` | AJAX helpers (jQuery-based `ajaxCommon.get/post/put/delete`) |
| `NThaiSmartWeb/wwwroot/js/face-recognition.js` | Face detection logic สำหรับ Step10 |
| `NThaiSmartWeb/wwwroot/js/signalr-config.js` | SignalR client: รับ card events → เรียก `next_page()` หรือ `setCardData()` |
| `NThaiSmartWeb/Views/Shared/_Layout.cshtml` | Layout หลัก + nav dropdown + ViewBag flags handler |
| `NThaiSmartWeb/Hubs/CardReaderHub.cs` | SignalR hub สำหรับ card reader events |
| `NThaiSmartWeb/wwwroot/css/home/index.css` | CSS หลักของทุก Step (~4700 lines) รวม `:root` design tokens |

---

## ViewBag Flags (Layout)

`_Layout.cshtml` ใช้ ViewBag flags เพื่อควบคุม UI elements:

| Flag | ผล |
|------|----|
| `HideHeader = true` | ซ่อน Bootstrap navbar (ยกเว้น dev mode — แสดงเสมอ) |
| `HideFooter = true` | ซ่อน `_Footer` partial |
| `HideButton = true` | ซ่อน back button footer |
| `ShowLangToggle = true` | แสดง `.lang-toggle-fixed` (fixed position) จาก Layout แทนที่จะ embed ใน header ของแต่ละ Step |

> Steps ที่ต้องการปุ่มเปลี่ยนภาษาให้ใช้ `ViewBag.ShowLangToggle = true` แล้วไม่ต้องใส่ `.lang-toggle-group` ใน header ของ step เอง

---

## JS Architecture

แต่ละ Step expose object ผ่าน `window.StepN`:

```js
window.Step3 = {
    init: async () => { /* เรียกตอน DOMContentLoaded */ },
    save_consent: () => { /* บันทึกข้อมูล */ }
};
```

`_Layout.cshtml` เรียก `window["Step" + stepName]?.init()` โดยอัตโนมัติ

## next_page() Auto-routing

`next_page(href, time_sec)` ใน `common-script.js`:
- ถ้าส่ง `href` → ไปหน้านั้นตรงๆ
- ถ้าไม่ส่ง `href` (เรียก `next_page()` เปล่า) → หาหน้าถัดไปอัตโนมัติ โดย fetch HEAD ทีละเลข (+1, +2, ...) ถ้าไม่มีหน้าไหนเลยจะไป StepEnd

## i18n

- ข้อความใน HTML ใช้ `data-i18n="key"` attribute
- `setLang('th'|'en')` ใน `common-script.js` จะ replace ข้อความทุก element ที่มี `data-i18n`
- Translation data โหลดจาก `/api/KioskApi/GetTranslate` และ cache ใน `localStorage["_i18n_data"]`

---

## Session/Local Storage

| Key | Storage | ใช้เก็บ |
|-----|---------|--------|
| `cardData` | session | ข้อมูลบัตรประชาชนที่อ่านได้ |
| `capture` | session | รูป face capture (base64) |
| `hasConsent` | session | flag ว่ายอมรับเงื่อนไขแล้ว |
| `CustomForm` | session | config ของ custom form |
| `CustomData` | session | ข้อมูลที่กรอกใน custom form |
| `IntegrateNdpp` | session | ข้อมูล NDPP ส่วนกลาง |
| `IntegrateNdppByKiosk` | session | ข้อมูล NDPP เฉพาะ Kiosk |
| `selectedKioskCode` | local | รหัส Kiosk ที่เลือก |
| `LoginDetail` | local | ข้อมูล login |
| `kioskHomeDelaySec` | local | วินาที auto-reset กลับ Step1 |
| `lang` | local | ภาษาที่เลือก (`th`/`en`) |
| `_i18n_data` | local | Translation cache จาก API |

---

## Design System

CSS ทั้งหมดอยู่ใน `wwwroot/css/home/index.css` ใช้ class-based system:

**Layout:** `.kiosk-body` → `.bg-decoration` + `.kiosk-content` → `.kiosk-header` + `.welcome-text-section` + content + `.kiosk-action-bar`

**Buttons:** `.kiosk-btn.btn-solid` (cyan), `.kiosk-btn.btn-outline` (white/red border) — ใช้ร่วมกับ `.kiosk-action-bar.style-modern`

**Error states:** ใช้ `.title-th-danger` + `.divider-danger` แทน `.title-th` + `.divider`

### CSS Design Tokens (`:root`)

สีทั้งหมดใน `index.css` อ้างอิงผ่าน CSS custom properties ที่ต้นไฟล์ — ห้ามใช้ hex ตรงๆ ใน rule ใหม่:

```css
/* Brand */
--maersk-cyan           #42b0d5    /* accent หลัก */
--maersk-cyan-rgb       66, 176, 213   /* สำหรับ rgba(var(--maersk-cyan-rgb), 0.1) */
--maersk-navy           #021B79    /* heading หลัก */
--maersk-navy-rgb       2, 27, 121
--maersk-navy-mid       #3852A3    /* gradient end */
--maersk-navy-dark      #002f86    /* hover/dark state */
--maersk-blue           #0073CF    /* secondary blue */

/* Status */
--maersk-danger         #dc3545
--maersk-danger-alt     #e74c3c
--maersk-success        #32BB71
--maersk-warning        #F59E0B

/* Text */
--maersk-text-dark      #1e293b
--maersk-text-body      #4b5563
--maersk-text-muted     #6b7280

/* Surface & Border */
--maersk-surface        #f1f5f9
--maersk-surface-cyan   #f0f9ff
--maersk-border         #e2e8f0
```

### Utility Classes

- `.welcome-text-section--compact` — margin น้อยกว่า (Step3)
- `.bottom-section--left` — instruction list ชิดซ้าย (Steps 6, 7, 8)
- `.v-kiosk-data-row--address` — address field แบบ column (Step12)
- `.id-card-image-pass--sm` — icon ขนาด 25% (Step8)
- `.kiosk-action-bar--compact` — margin-top น้อยกว่า (Step12)
- `.instruction-block--card` — กล่องขาวโปร่งใส สีข้อความ dark (StepEnd)
- `.terms-footer-fixed .kiosk-action-bar` — scoped compact bar ใน Step3 footer
