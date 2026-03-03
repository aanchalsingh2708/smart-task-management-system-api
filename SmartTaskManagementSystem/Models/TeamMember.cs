using System;
using System.Collections.Generic;

namespace SmartTaskManagementSystem.Models;

public partial class TeamMember
{
    public int UserId { get; set; }

    public int TeamId { get; set; }

    public string? Role { get; set; }

    public DateTime JoinedAt { get; set; }

    public virtual Team Team { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
