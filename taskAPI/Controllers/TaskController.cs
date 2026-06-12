using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace taskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tasksController : ControllerBase
    {
        private readonly TaskAppService.TaskAppService _appservice; 

        public tasksController()
        {
            _appservice = new TaskAppService.TaskAppService();
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskModel.TaskItem>> GetAllAccounts()
        {
            var accounts = _appservice.GetTasks();
            return Ok(accounts);
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] string task)
        { 
            string result = _appservice.addTask(task);
             
            if (result == "Error: Task cannot be empty.")
            {
                return BadRequest(new { error = result });
            }
             
            return Created(string.Empty, new { message = result, taskName = task });
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateTask(int id, [FromBody] string newName)
        {
            string result = _appservice.addEdit(id, newName);

            if (result == "Invalid id!" || result == "Task cannot be empty")
            {
                return BadRequest(new { error = result });
            }

            if (result == "Error: Task ID not found.")
            {
                return NotFound(new { error = result });
            }

            return Ok(new { message = result, updatedId = id, updatedName = newName });
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteTask(int id)
        {
            string result = _appservice.addDelete(id);

            if (result == "Invalid id!")
            {
                return BadRequest(new { error = result });
            }

            if (result == "Task ID not found.")
            {
                return NotFound(new { error = result });
            }

            return Ok(new { message = result, deletedId = id });
        }

        [HttpPatch("{id:int}/status")]
        public IActionResult MarkTaskStatus(int id, [FromBody] string status)
        {
            string result = _appservice.addMarkTask(id, status);

            if (result == "Invalid id!")
            {
                return BadRequest(new { error = result });
            }

            if (result == "Task ID not found.")
            {
                return NotFound(new { error = result });
            }

            return Ok(new { message = result, taskId = id, currentStatus = status });
        }

       
    }
}
