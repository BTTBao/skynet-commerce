using System;
using System.Collections.Generic;

namespace WebEBackend.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int ProductId { get; set; }

    public int AccountId { get; set; }

    public int ShopId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Status { get; set; }

    public int? OrderDetailId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual OrderDetail? OrderDetail { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Shop Shop { get; set; } = null!;
}
