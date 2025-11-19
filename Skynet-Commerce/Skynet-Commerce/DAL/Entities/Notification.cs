namespace Skynet_Commerce.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notification
    {
        public long NotificationID { get; set; }

        public int AccountID { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Message { get; set; }

        [StringLength(500)]
        public string LinkURL { get; set; }

        public bool? IsRead { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual Account Account { get; set; }
    }
}
