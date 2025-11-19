namespace Skynet_Commerce.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Wishlist
    {
        public int WishlistID { get; set; }

        public int AccountID { get; set; }

        public int ProductID { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual Account Account { get; set; }

        public virtual Product Product { get; set; }
    }
}
