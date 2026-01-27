using System;
using System.Collections.Generic;

namespace WebEBackend.Models;

public partial class ShopRegistration
{
    public int RegistrationId { get; set; }

    public int AccountId { get; set; }

    public string ShopName { get; set; } = null!;

    public string? Description { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ReviewedAt { get; set; }

    public virtual Account Account { get; set; } = null!;
}
