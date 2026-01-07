namespace Skynet_Ecommerce
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserAddress
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserAddress()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int AddressID { get; set; }

        public int AccountID { get; set; }

        [StringLength(100)]
        public string AddressName { get; set; }

        [Required]
        [StringLength(150)]
        public string ReceiverFullName { get; set; }

        [Required]
        [StringLength(10)]
        public string ReceiverPhone { get; set; }

        [Required]
        [StringLength(255)]
        public string AddressLine { get; set; }

        [Required]
        [StringLength(100)]
        public string Ward { get; set; }

        [Required]
        [StringLength(100)]
        public string District { get; set; }

        [Required]
        [StringLength(100)]
        public string Province { get; set; }

        public bool? IsDefault { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
