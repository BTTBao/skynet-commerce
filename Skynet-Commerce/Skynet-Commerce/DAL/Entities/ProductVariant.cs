namespace Skynet_Commerce.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductVariant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductVariant()
        {
            CartItems = new HashSet<CartItem>();
            FlashSaleProducts = new HashSet<FlashSaleProduct>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int VariantID { get; set; }

        public int ProductID { get; set; }

        [StringLength(50)]
        public string Size { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(100)]
        public string SKU { get; set; }

        public decimal? Price { get; set; }

        public int? StockQuantity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartItem> CartItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FlashSaleProduct> FlashSaleProducts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual Product Product { get; set; }
    }
}
