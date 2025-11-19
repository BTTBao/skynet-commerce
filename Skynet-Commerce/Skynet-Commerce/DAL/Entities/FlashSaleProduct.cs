namespace Skynet_Commerce.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FlashSaleProduct
    {
        public int FlashSaleProductID { get; set; }

        public int FlashSaleID { get; set; }

        public int ProductID { get; set; }

        public int? VariantID { get; set; }

        public decimal? FlashSalePrice { get; set; }

        public int? TotalStock { get; set; }

        public int? SoldCount { get; set; }

        public virtual FlashSale FlashSale { get; set; }

        public virtual Product Product { get; set; }

        public virtual ProductVariant ProductVariant { get; set; }
    }
}
