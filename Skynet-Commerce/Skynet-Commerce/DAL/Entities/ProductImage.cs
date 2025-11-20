namespace Skynet_Commerce.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductImage
    {
        [Key]
        public int ImageID { get; set; }

        public int ProductID { get; set; }

        [Required]
        [StringLength(500)]
        public string ImageURL { get; set; }

        [StringLength(255)]
        public string ImagePublicId { get; set; }

        public bool? IsPrimary { get; set; }

        public virtual Product Product { get; set; }
    }
}
