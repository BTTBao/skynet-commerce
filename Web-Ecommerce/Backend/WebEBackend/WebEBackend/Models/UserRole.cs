using System;
using System.Collections.Generic;

namespace WebEBackend.Models;

public partial class UserRole
{
    public int UserRoleId { get; set; }

    public int AccountId { get; set; }

    public string RoleName { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Account Account { get; set; } = null!;
}
