using System;
using System.Collections.Generic;

namespace WebEBackend.Models;

public partial class ShippingPartner
{
    public int ShipperId { get; set; }

    public string Name { get; set; } = null!;

    public string? LogoUrl { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<OrderShippingInfo> OrderShippingInfos { get; set; } = new List<OrderShippingInfo>();
}
