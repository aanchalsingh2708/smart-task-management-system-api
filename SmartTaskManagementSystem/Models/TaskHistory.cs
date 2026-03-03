using System;
using System.Collections.Generic;

namespace SmartTaskManagementSystem.Models;

public partial class TaskHistory
{
    public int HistoryId { get; set; }

    public int TaskId { get; set; }

    public string ChangedField { get; set; } = null!;

    public string? OldValue { get; set; }

    public string? NewValue { get; set; }

    public int ChangedBy { get; set; }

    public DateTime ChangedAt { get; set; }

    public virtual User ChangedByNavigation { get; set; } = null!;

    public virtual TaskItem Task { get; set; } = null!;
}
