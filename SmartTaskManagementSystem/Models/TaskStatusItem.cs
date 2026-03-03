using System;
using System.Collections.Generic;

namespace SmartTaskManagementSystem.Models;

public partial class TaskStatusItem
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public bool IsClosed { get; set; }

    public virtual ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
}
