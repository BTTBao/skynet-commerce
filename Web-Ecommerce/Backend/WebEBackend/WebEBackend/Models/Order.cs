using System;
using System.Collections.Generic;

namespace WebEBackend.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int OrderGroupId { get; set; }

    public int ShopId { get; set; }

    public int AccountId { get; set; }

    public int? AddressId { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsReviewed { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual UserAddress? Address { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual OrderGroup OrderGroup { get; set; } = null!;

    public virtual ICollection<OrderShippingInfo> OrderShippingInfos { get; set; } = new List<OrderShippingInfo>();

    public virtual ICollection<OrderStatusHistory> OrderStatusHistories { get; set; } = new List<OrderStatusHistory>();

    public virtual Shop Shop { get; set; } = null!;
}
