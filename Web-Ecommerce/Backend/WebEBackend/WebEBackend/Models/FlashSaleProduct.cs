using System;
using System.Collections.Generic;

namespace WebEBackend.Models;

public partial class FlashSaleProduct
{
    public int FlashSaleProductId { get; set; }

    public int FlashSaleId { get; set; }

    public int ProductId { get; set; }

    public int? VariantId { get; set; }

    public decimal? FlashSalePrice { get; set; }

    public int? TotalStock { get; set; }

    public int? SoldCount { get; set; }

    public virtual FlashSale FlashSale { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual ProductVariant? Variant { get; set; }
}
