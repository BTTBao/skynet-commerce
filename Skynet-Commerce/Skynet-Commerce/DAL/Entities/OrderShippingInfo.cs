namespace Skynet_Commerce.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderShippingInfo")]
    public partial class OrderShippingInfo
    {
        [Key]
        public int ShippingInfoID { get; set; }

        public int OrderID { get; set; }

        public int? ShipperID { get; set; }

        [StringLength(100)]
        public string TrackingCode { get; set; }

        public decimal? ShippingFee { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EstimatedDeliveryDate { get; set; }

        public virtual Order Order { get; set; }

        public virtual ShippingPartner ShippingPartner { get; set; }
    }
}
