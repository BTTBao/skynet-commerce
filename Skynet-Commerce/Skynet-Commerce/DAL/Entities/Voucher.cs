namespace Skynet_Commerce.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Voucher
    {
        public int VoucherID { get; set; }

        public int? ShopID { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        public string Description { get; set; }

        public decimal? DiscountPercent { get; set; }

        public decimal? MinOrderAmount { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
