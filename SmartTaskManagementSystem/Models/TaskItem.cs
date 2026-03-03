using System;
using System.Collections.Generic;

namespace SmartTaskManagementSystem.Models;

public partial class TaskItem
{
    public int TaskId { get; set; }

    public int ProjectId { get; set; }

    public int AssignedTo { get; set; }

    public int StatusId { get; set; }

    public int PriorityId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? DueDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ChangedAt { get; set; }

    public virtual User AssignedToNavigation { get; set; } = null!;

    public virtual TaskPriority Priority { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual TaskStatusItem Status { get; set; } = null!;

    public virtual ICollection<TaskComment> TaskComments { get; set; } = new List<TaskComment>();

    public virtual ICollection<TaskHistory> TaskHistories { get; set; } = new List<TaskHistory>();
}
