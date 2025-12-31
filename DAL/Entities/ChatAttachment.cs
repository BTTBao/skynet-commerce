namespace Skynet_Ecommerce
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChatAttachment
    {
        [Key]
        public int AttachmentID { get; set; }

        public int MessageID { get; set; }

        [StringLength(500)]
        public string FileURL { get; set; }

        [StringLength(255)]
        public string FilePublicId { get; set; }

        [StringLength(50)]
        public string FileType { get; set; }

        public virtual ChatMessage ChatMessage { get; set; }
    }
}
