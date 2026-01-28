using System;
using System.Collections.Generic;

namespace WebEBackend.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int OrderGroupId { get; set; }

    public string? Method { get; set; }

    public decimal? Amount { get; set; }

    public string? PaymentStatus { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual OrderGroup OrderGroup { get; set; } = null!;
}
