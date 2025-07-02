using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class Staff
{
    public uint StaffId { get; set; }

    public uint? PrefixId { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public uint GenderId { get; set; }

    public uint PositionId { get; set; }

    public uint SectionId { get; set; }

    public uint DepartmentId { get; set; }

    public string TeamId { get; set; } = null!;

    public string EmployeeId { get; set; } = null!;

    public uint StaffStatusId { get; set; }

    public string Mobile { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public uint OfficeId { get; set; }

    public uint RoleId { get; set; }

    public uint BusinessProfileId { get; set; }

    public uint BossId { get; set; }

    public bool SeeCasesInTeam { get; set; }

    public bool SeeCasesInSection { get; set; }

    public bool SeeCasesInDepartment { get; set; }

    public bool SeeCasesAll { get; set; }

    public string Comment { get; set; } = null!;

    public byte Inactive { get; set; }

    public DateOnly HireDate { get; set; }

    public string ProfileImage { get; set; } = null!;

    public uint BisHourProfileId { get; set; }

    public byte InactiveChatbot { get; set; }

    public virtual Prefix? Prefix { get; set; }
}
