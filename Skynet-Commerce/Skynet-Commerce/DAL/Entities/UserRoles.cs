namespace Skynet_Commerce.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserRoles
    {
        [Key]
        public int UserRoleID { get; set; }

        public int AccountID { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
