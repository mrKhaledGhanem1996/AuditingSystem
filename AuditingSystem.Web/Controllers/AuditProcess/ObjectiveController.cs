using AuditingSystem.Entities.AuditProcess;
using AuditingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AuditingSystem.Web.Controllers.AuditProcess
{
    public class ObjectiveController : Controller
    {
        private readonly IBaseRepository<Activity, int> _activityRepository;
        private readonly IBaseRepository<Objective, int> _objectiveRepository;
        public ObjectiveController(
            IBaseRepository<Activity, int> activityRepository,
            IBaseRepository<Objective, int> objectiveRepository)
        {
            _activityRepository = activityRepository;
            _objectiveRepository = objectiveRepository;
        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var objectives = await _objectiveRepository.ListAsync(
                  c => c.IsDeleted == false,
                  q => q.OrderBy(u => u.Id),
                  c => c.Activity);

            var model = objectives.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.TotalRow = objectives.Count();
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling(objectives.Count() / (double)pageSize);
            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            var activity = _activityRepository.ListAsync(
                  u => u.IsDeleted == false,
                  q => q.OrderBy(u => u.Id),
                  null).Result;

            ViewBag.ActivityId = new SelectList(activity, "Id", "Name");

            return View();
        }


        public async Task<IActionResult> Edit(int id)
        {
            var objective = await _objectiveRepository.FindByAsync(id);

            var activity = _activityRepository.ListAsync(
                  u => u.IsDeleted == false,
                  q => q.OrderBy(u => u.Id),
                  null).Result;

            ViewBag.ActivityId = new SelectList(activity, "Id", "Name", objective.ActivityId);

            return View(objective);
        }
    }
}
