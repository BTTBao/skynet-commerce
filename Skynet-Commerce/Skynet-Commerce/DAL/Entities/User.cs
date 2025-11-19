namespace Skynet_Commerce.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [Key]
        public int UserID { get; set; }

        public int? AccountID { get; set; }

        [StringLength(150)]
        public string FullName { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [StringLength(500)]
        public string AvatarURL { get; set; }

        [StringLength(255)]
        public string AvatarPublicId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }
    }
}
