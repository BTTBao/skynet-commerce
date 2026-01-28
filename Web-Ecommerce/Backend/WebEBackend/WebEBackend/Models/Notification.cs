using System;
using System.Collections.Generic;

namespace WebEBackend.Models;

public partial class Notification
{
    public long NotificationId { get; set; }

    public int AccountId { get; set; }

    public string? Title { get; set; }

    public string? Message { get; set; }

    public string? LinkUrl { get; set; }

    public bool? IsRead { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Account Account { get; set; } = null!;
}
