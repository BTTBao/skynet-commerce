namespace Skynet_Commerce.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payment
    {
        public int PaymentID { get; set; }

        public int OrderGroupID { get; set; }

        [StringLength(20)]
        public string Method { get; set; }

        public decimal? Amount { get; set; }

        [StringLength(20)]
        public string PaymentStatus { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual OrderGroup OrderGroup { get; set; }
    }
}
