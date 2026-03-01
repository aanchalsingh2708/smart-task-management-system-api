namespace SmartTaskManagementSystem.Services.Interfaces
{
    public interface ITaskService
    {
        string GetAllTasks();
        string GetTaskById(int taskId);
    }
}
