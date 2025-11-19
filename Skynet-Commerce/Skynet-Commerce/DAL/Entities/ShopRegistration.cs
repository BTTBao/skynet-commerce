namespace Skynet_Commerce.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ShopRegistration
    {
        [Key]
        public int RegistrationID { get; set; }

        public int AccountID { get; set; }

        [Required]
        [StringLength(200)]
        public string ShopName { get; set; }

        public string Description { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ReviewedAt { get; set; }

        public virtual Account Account { get; set; }
    }
}
