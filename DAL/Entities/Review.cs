namespace Skynet_Ecommerce
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Review
    {
        public int ReviewID { get; set; }

        public int ProductID { get; set; }

        public int AccountID { get; set; }

        public int ShopID { get; set; }

        public int? Rating { get; set; }

        public string Comment { get; set; }

        public DateTime? CreatedAt { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        public int? OrderDetailID { get; set; }

        public virtual Account Account { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }

        public virtual Product Product { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
