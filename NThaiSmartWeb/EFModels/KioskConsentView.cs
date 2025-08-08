using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class KioskConsentView
{
    public string? KioskCode { get; set; }

    public string? KioskName { get; set; }

    /// <summary>
    /// เลขที่สัญญา
    /// </summary>
    public string? ContractCode { get; set; }

    public string? ContractName { get; set; }

    public DateTime ConsentedDateTime { get; set; }

    public DateOnly? ConsentedDate { get; set; }

    public TimeOnly? ConsentedTime { get; set; }

    public string? TextConsentedDateTime { get; set; }

    public string? TextConsentedDate { get; set; }

    public string? TextConsentedTime { get; set; }

    public string? TextConsentedHour { get; set; }

    public string? ConsentedDay { get; set; }

    public string? CitizenId { get; set; }

    public string? FullNameTh { get; set; }

    public string? FullNameEn { get; set; }
}
