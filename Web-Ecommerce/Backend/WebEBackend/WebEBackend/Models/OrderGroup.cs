using System;
using System.Collections.Generic;

namespace WebEBackend.Models;

public partial class OrderGroup
{
    public int OrderGroupId { get; set; }

    public int AccountId { get; set; }

    public decimal? TotalAmount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
