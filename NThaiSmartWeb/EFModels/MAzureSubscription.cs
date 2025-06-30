using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class MAzureSubscription
{
    public uint AzureId { get; set; }

    public string AzureSubscriptionName { get; set; } = null!;

    public string AzureSubscriptionId { get; set; } = null!;

    public string AzureSubscriptionTenantId { get; set; } = null!;

    public string AzureSubscriptionClientId { get; set; } = null!;

    public string AzureSubscriptionClientSecret { get; set; } = null!;

    public string AzureSubscriptionResource { get; set; } = null!;

    public string AzureSubscriptionGrantType { get; set; } = null!;

    public DateTime AzureSubscriptionLastCheckedDate { get; set; }

    public DateTime AzureSubscriptionCreatedDate { get; set; }

    public uint AzureSubscriptionCreatedBy { get; set; }

    public DateTime? AzureSubscriptionUpdatedDate { get; set; }

    public uint? AzureSubscriptionUpdatedBy { get; set; }
}
