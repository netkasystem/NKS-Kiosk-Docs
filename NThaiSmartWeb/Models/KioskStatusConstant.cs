public static class KioskStatusConstant
{
    // Raw Status
    public const string Connected = "✅ Connected";
    public const string Disconnected = "🔌 Disconnected";
    public const string Ready = "ready";
    public const string CardDetected = "card_detected";
    public const string CardRemoved = "card_removed";
    public const string Waiting = "waiting";
    public const string CardError = "card_error";

    // Display Message (สำหรับผู้ใช้)
    public const string ReadyText = "📗 พร้อมให้บริการ";
    public const string CardDetectedText = "📥 ตรวจพบบัตร";
    public const string CardRemovedText = "📤 บัตรถูกถอดออกแล้ว";
    public const string WaitingText = "⏳ กรุณาเสียบบัตรประชาชน";
    public const string CardErrorText = "❌ ไม่สามารถอ่านข้อมูลจากบัตรได้ กรุณาใช้บัตรใบอื่นหรือแจ้งเจ้าหน้าที่";

    // Log Message (สำหรับ backend/dev)
    public const string CardErrorLog = "Smart card communication failed. Possibly damaged or unreadable.";
}
