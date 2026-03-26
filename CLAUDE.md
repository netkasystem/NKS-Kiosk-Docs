# N-Kiosk-Web - Kiosk Identity Verification System

## Step Flow Overview

ระบบยืนยันตัวตนผ่านบัตรประชาชนบน Kiosk โดยมี flow หลักดังนี้:

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

## Key Files

| ไฟล์ | คำอธิบาย |
|------|----------|
| `NThaiSmartWeb/Controllers/StepController.cs` | Controller ที่ register action ของแต่ละ Step |
| `NThaiSmartWeb/wwwroot/js/step-controller.js` | JS logic ของทุก Step (init, save, navigation) |
| `NThaiSmartWeb/wwwroot/js/common-script.js` | Utility functions: encrypt/decrypt, session storage, `next_page()`, `findNextStep()` |
| `NThaiSmartWeb/wwwroot/js/common-ajax.js` | AJAX helpers |
| `NThaiSmartWeb/wwwroot/js/face-recognition.js` | Face detection logic สำหรับ Step10 |
| `NThaiSmartWeb/Views/Shared/_Layout.cshtml` | Layout หลัก + nav dropdown ของทุก Step |
| `NThaiSmartWeb/Hubs/CardReaderHub.cs` | SignalR hub สำหรับ card reader events |

## next_page() Auto-routing

`next_page(href, time_sec)` ใน `common-script.js`:
- ถ้าส่ง `href` → ไปหน้านั้นตรงๆ
- ถ้าไม่ส่ง `href` (เรียก `next_page()` เปล่า) → หาหน้าถัดไปอัตโนมัติ โดย fetch HEAD ทีละเลข (+1, +2, ...) ถ้าไม่มีหน้าไหนเลยจะไป StepEnd

## Session/Local Storage

| Key | ใช้เก็บ |
|-----|--------|
| `cardData` | ข้อมูลบัตรประชาชนที่อ่านได้ |
| `capture` | รูป face capture (base64) |
| `hasConsent` | flag ว่ายอมรับเงื่อนไขแล้ว |
| `CustomForm` | config ของ custom form |
| `CustomData` | ข้อมูลที่กรอกใน custom form |
| `IntegrateNdpp` | ข้อมูล NDPP ส่วนกลาง |
| `IntegrateNdppByKiosk` | ข้อมูล NDPP เฉพาะ Kiosk |
| `selectedKioskCode` (localStorage) | รหัส Kiosk ที่เลือก |
| `LoginDetail` (localStorage) | ข้อมูล login |
| `kioskHomeDelaySec` (localStorage) | วินาที auto-reset กลับ Step1 |
