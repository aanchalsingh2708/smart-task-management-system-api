using System;
using System.Collections.Generic;

namespace SmartTaskManagementSystem.Models;

public partial class VwTaskDashboard
{
    public int Taskid { get; set; }

    public string Title { get; set; } = null!;

    public string AssignedTo { get; set; } = null!;

    public string StatusName { get; set; } = null!;

    public string Priorityname { get; set; } = null!;

    public DateOnly? Duedate { get; set; }
}
