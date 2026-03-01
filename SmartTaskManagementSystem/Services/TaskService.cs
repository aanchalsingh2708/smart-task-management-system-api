using SmartTaskManagementSystem.Services.Interfaces;

namespace SmartTaskManagementSystem.Services
{
    public class TaskService : ITaskService
    {
        public string GetAllTasks()
        {
            return "All task from task service";
        }

        public string GetTaskById(int taskId)
        {
            return $"Task {taskId} from TaskService";
        }
    }
}
