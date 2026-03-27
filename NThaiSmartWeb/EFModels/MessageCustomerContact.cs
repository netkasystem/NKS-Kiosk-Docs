using System;
using System.Collections.Generic;

namespace NThaiSmartWeb.EFModels;

public partial class MessageCustomerContact
{
    public uint MessageCustomerId { get; set; }

    public uint ContactId { get; set; }
}

