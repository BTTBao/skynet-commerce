namespace Skynet_Ecommerce
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChatMessage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChatMessage()
        {
            ChatAttachments = new HashSet<ChatAttachment>();
        }

        [Key]
        public int MessageID { get; set; }

        public int RoomID { get; set; }

        public int SenderID { get; set; }

        [StringLength(20)]
        public string MessageType { get; set; }

        public string MessageText { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChatAttachment> ChatAttachments { get; set; }

        public virtual ChatRoom ChatRoom { get; set; }
    }
}
