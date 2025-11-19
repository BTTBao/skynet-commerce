namespace Skynet_Commerce.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CartItem
    {
        public int CartItemID { get; set; }

        public int CartID { get; set; }

        public int ProductID { get; set; }

        public int? VariantID { get; set; }

        public int? Quantity { get; set; }

        public DateTime? AddedAt { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual Product Product { get; set; }

        public virtual ProductVariant ProductVariant { get; set; }
    }
}
