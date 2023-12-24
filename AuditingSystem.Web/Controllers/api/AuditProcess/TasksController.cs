using AuditingSystem.Entities.AuditProcess;
using AuditingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AuditingSystem.Web.Controllers.api.AuditProcess
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IBaseRepository<Tasks, int> _taskRepository;

        public TasksController(IBaseRepository<Tasks, int> taskRepository)
        {
            _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var tasks = await _taskRepository.ListAsync();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = $"Error retrieving tasks: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _taskRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = $"Error deleting task: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Tasks task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _taskRepository.CreateAsync(task);
                    return NoContent();
                }

                return BadRequest(new { error = "Invalid ModelState" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = $"Error adding task: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] Tasks updatedTask)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingTask = await _taskRepository.FindByAsync(id);

                    if (existingTask == null)
                    {
                        return NotFound(new { error = $"Task with ID {id} not found" });
                    }

                    // تحديث الخصائص
                    existingTask.Name = updatedTask.Name;
                    existingTask.Description = updatedTask.Description;
                    existingTask.ObjectiveId = updatedTask.ObjectiveId;

                    await _taskRepository.UpdateAsync(existingTask);

                    return NoContent();
                }

                return BadRequest(new { error = "Invalid ModelState" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = $"Error updating task: {ex.Message}" });
            }
        }
    }
}
