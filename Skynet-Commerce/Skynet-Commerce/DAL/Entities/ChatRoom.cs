namespace Skynet_Commerce.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChatRoom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChatRoom()
        {
            ChatMessages = new HashSet<ChatMessage>();
        }

        [Key]
        public int RoomID { get; set; }

        public int BuyerID { get; set; }

        public int ShopID { get; set; }

        public DateTime? CreatedAt { get; set; }

        public bool? IsClosed { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
