using AuditingSystem.Entities.AuditProcess;
using AuditingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AuditingSystem.Web.Controllers.api.AuditProcess
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IBaseRepository<Department, int> _departmentRepository;

        public DepartmentsController(IBaseRepository<Department, int> departmentRepository)
        {
            _departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentRepository.ListAsync();
            return Ok(departments);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _departmentRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = $"Error deleting department: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _departmentRepository.CreateAsync(department);
                    return NoContent();
                }

                return BadRequest("Invalid ModelState");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = $"Error adding department: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] Department updatedDepartment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingDepartment = await _departmentRepository.FindByAsync(id);

                    if (existingDepartment == null)
                    {
                        return NotFound(new { error = $"Department with ID {id} not found" });
                    }

                    // تحديث الخصائص
                    existingDepartment.Name = updatedDepartment.Name;
                    existingDepartment.Description = updatedDepartment.Description;
                    existingDepartment.CompanyId = updatedDepartment.CompanyId;

                    await _departmentRepository.UpdateAsync(existingDepartment);

                    return NoContent();
                }

                return BadRequest(new { error = "Invalid ModelState" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = $"Error updating department: {ex.Message}" });
            }
        }
    }
}
