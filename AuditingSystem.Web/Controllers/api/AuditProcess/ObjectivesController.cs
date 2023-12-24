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
    public class ObjectivesController : ControllerBase
    {
        private readonly IBaseRepository<Objective, int> _objectiveRepository;

        public ObjectivesController(IBaseRepository<Objective, int> objectiveRepository)
        {
            _objectiveRepository = objectiveRepository ?? throw new ArgumentNullException(nameof(objectiveRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var objectives = await _objectiveRepository.ListAsync();
                return Ok(objectives);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = $"Error retrieving objectives: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _objectiveRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = $"Error deleting objective: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Objective objective)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _objectiveRepository.CreateAsync(objective);
                    return NoContent();
                }

                return BadRequest(new { error = "Invalid ModelState" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = $"Error adding objective: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] Objective updatedObjective)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingObjective = await _objectiveRepository.FindByAsync(id);

                    if (existingObjective == null)
                    {
                        return NotFound(new { error = $"Objective with ID {id} not found" });
                    }

                    // تحديث الخصائص
                    existingObjective.Name = updatedObjective.Name;
                    existingObjective.Description = updatedObjective.Description;
                    existingObjective.ActivityId = updatedObjective.ActivityId;

                    await _objectiveRepository.UpdateAsync(existingObjective);

                    return NoContent();
                }

                return BadRequest(new { error = "Invalid ModelState" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = $"Error updating objective: {ex.Message}" });
            }
        }
    }
}
