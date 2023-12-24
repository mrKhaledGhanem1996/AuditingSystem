using AuditingSystem.Entities.AuditProcess;
using AuditingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AuditingSystem.Web.Controllers.AuditProcess
{
    public class PracticeController : Controller
    {
        private readonly IBaseRepository<Tasks, int> _tasksRepository;
        private readonly IBaseRepository<Practice, int> _practiceRepository;
        public PracticeController(
            IBaseRepository<Tasks, int> tasksRepository,
            IBaseRepository<Practice, int> practiceRepository)
        {
            _tasksRepository = tasksRepository;
            _practiceRepository = practiceRepository;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var PRACTICE = await _practiceRepository.ListAsync(
                  c => c.IsDeleted == false,
                  q => q.OrderBy(u => u.Id),
                  c => c.Task);

            var model = PRACTICE.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.TotalRow = PRACTICE.Count();
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling(PRACTICE.Count() / (double)pageSize);
            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            var task = _tasksRepository.ListAsync(
                  u => u.IsDeleted == false,
                  q => q.OrderBy(u => u.Id),
                  null).Result;

            ViewBag.TaskId = new SelectList(task, "Id", "Name");

            return View();
        }


        public async Task<IActionResult> Edit(int id)
        {
            var practice = await _practiceRepository.FindByAsync(id);

            var task = _tasksRepository.ListAsync(
                  u => u.IsDeleted == false,
                  q => q.OrderBy(u => u.Id),
                  null).Result;

            ViewBag.TaskId = new SelectList(task, "Id", "Name", practice.TaskId);

            return View(practice);
        }
    }
}
