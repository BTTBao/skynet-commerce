using System;
using System.Collections.Generic;

namespace WebEBackend.Models;

public partial class OrderShippingInfo
{
    public int ShippingInfoId { get; set; }

    public int OrderId { get; set; }

    public int? ShipperId { get; set; }

    public string? TrackingCode { get; set; }

    public decimal? ShippingFee { get; set; }

    public string? Status { get; set; }

    public DateOnly? EstimatedDeliveryDate { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual ShippingPartner? Shipper { get; set; }
}
