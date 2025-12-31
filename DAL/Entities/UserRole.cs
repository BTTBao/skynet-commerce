namespace Skynet_Ecommerce
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserRole
    {
        public int UserRoleID { get; set; }

        public int AccountID { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual Account Account { get; set; }
    }
}
