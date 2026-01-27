using System;
using System.Collections.Generic;

namespace WebEBackend.Models;

public partial class Shop
{
    public int ShopId { get; set; }

    public int AccountId { get; set; }

    public string ShopName { get; set; } = null!;

    public string? Description { get; set; }

    public string? AvatarUrl { get; set; }

    public string? CoverImageUrl { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public decimal? RatingAverage { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<ChatRoom> ChatRooms { get; set; } = new List<ChatRoom>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
}
