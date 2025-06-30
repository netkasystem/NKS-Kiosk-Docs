using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Calendar
{
    public uint Id { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public string Recurrence { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string Body { get; set; } = null!;

    public string Column { get; set; } = null!;

    public byte Allday { get; set; }

    public string Color { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Sms { get; set; } = null!;

    public DateTime CreatedTime { get; set; }

    public uint CreatedBy { get; set; }

    public byte Restrict { get; set; }

    public uint CType { get; set; }

    public uint RoomId { get; set; }

    public uint WebexReserve { get; set; }

    public uint CaseRef { get; set; }

    public uint ModuleId { get; set; }
}
