using Microsoft.AspNetCore.Mvc;
using SmartTaskManagementSystem.Services;
using SmartTaskManagementSystem.Services.Interfaces;

namespace SmartTaskManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _taskService.GetAllTasks();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _taskService.GetTaskById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create()
        {
            return StatusCode(201, "Task Created");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            return Ok($"Task {id} updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
