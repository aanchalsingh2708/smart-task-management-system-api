using System;
using System.Collections.Generic;

namespace SmartTaskManagementSystem.Models;

public partial class TaskComment
{
    public int CommentId { get; set; }

    public int TaskId { get; set; }

    public string CommentText { get; set; } = null!;

    public int CommentedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User CommentedByNavigation { get; set; } = null!;

    public virtual TaskItem Task { get; set; } = null!;
}
