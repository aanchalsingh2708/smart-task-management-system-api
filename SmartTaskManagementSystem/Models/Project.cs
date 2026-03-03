using System;
using System.Collections.Generic;

namespace SmartTaskManagementSystem.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public int TeamId { get; set; }

    public string ProjectName { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();

    public virtual Team Team { get; set; } = null!;
}
