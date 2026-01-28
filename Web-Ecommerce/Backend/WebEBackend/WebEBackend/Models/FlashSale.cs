using System;
using System.Collections.Generic;

namespace WebEBackend.Models;

public partial class FlashSale
{
    public int FlashSaleId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<FlashSaleProduct> FlashSaleProducts { get; set; } = new List<FlashSaleProduct>();
}
