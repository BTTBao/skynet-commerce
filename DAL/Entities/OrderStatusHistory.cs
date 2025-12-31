namespace Skynet_Ecommerce
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderStatusHistory")]
    public partial class OrderStatusHistory
    {
        [Key]
        public int HistoryID { get; set; }

        public int OrderID { get; set; }

        [StringLength(20)]
        public string OldStatus { get; set; }

        [StringLength(20)]
        public string NewStatus { get; set; }

        public DateTime? ChangedAt { get; set; }

        public virtual Order Order { get; set; }
    }
}
