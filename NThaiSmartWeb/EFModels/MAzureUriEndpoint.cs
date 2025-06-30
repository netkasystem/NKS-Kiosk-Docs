using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class MAzureUriEndpoint
{
    public uint AzureUriEndpointId { get; set; }

    public uint? AzureUriEndpointParentId { get; set; }

    public string AzureUriEndpointName { get; set; } = null!;

    public string AzureUriEndpointType { get; set; } = null!;

    public string AzureUriEndpointAction { get; set; } = null!;

    public string AzureUriEndpointUri { get; set; } = null!;

    public uint? AzureUriEndpointIntervalMinutes { get; set; }

    public ulong AzureUriEndpointInactive { get; set; }

    public DateTime AzureUriEndpointCreatedDate { get; set; }

    public uint AzureUriEndpointCreatedBy { get; set; }

    public DateTime? AzureUriEndpointUpdatedDate { get; set; }

    public uint? AzureUriEndpointUpdatedBy { get; set; }

    public uint? MAzureSubscriptionAzureId { get; set; }
}
