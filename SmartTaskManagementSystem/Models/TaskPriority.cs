using System;
using System.Collections.Generic;

namespace SmartTaskManagementSystem.Models;

public partial class TaskPriority
{
    public int PriorityId { get; set; }

    public string PriorityName { get; set; } = null!;

    public int PriorityOrder { get; set; }

    public virtual ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
}
