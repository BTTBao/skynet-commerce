using System;
using System.Collections.Generic;

namespace WebEBackend.Models;

public partial class ChatRoom
{
    public int RoomId { get; set; }

    public int BuyerId { get; set; }

    public int ShopId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsClosed { get; set; }

    public virtual Account Buyer { get; set; } = null!;

    public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();

    public virtual Shop Shop { get; set; } = null!;
}
