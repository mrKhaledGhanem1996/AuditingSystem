using AuditingSystem.Entities.AuditProcess;
using AuditingSystem.Entities.RiskAssessments;
using AuditingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AuditingSystem.Web.Controllers.AuditProcess
{
    public class ActivityController : Controller
    {
        private readonly IBaseRepository<Activity, int> _activityRepository;
        private readonly IBaseRepository<Function, int> _functionRepository;
        public ActivityController(
            IBaseRepository<Activity, int> activityRepository,
            IBaseRepository<Function, int> functionRepository)
        {
            _activityRepository = activityRepository;
            _functionRepository = functionRepository;
        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var activities = await _activityRepository.ListAsync(
                  c => c.IsDeleted == false,
                  q => q.OrderBy(u => u.Id),
            c => c.Function);

            var model = activities.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.TotalRow = activities.Count();
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling(activities.Count() / (double)pageSize);

            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            var function = _functionRepository.ListAsync(
                  u => u.IsDeleted == false,
                  q => q.OrderBy(u => u.Id),
                  null).Result;

            ViewBag.FunctionId = new SelectList(function, "Id", "Name");

            return View();
        }


        public async Task<IActionResult> Edit(int id)
        {
            var activity = await _activityRepository.FindByAsync(id);

            var function = _functionRepository.ListAsync(
                  u => u.IsDeleted == false,
                  q => q.OrderBy(u => u.Id),
                  null).Result;

            ViewBag.FunctionId = new SelectList(function, "Id", "Name", activity.FunctionId);

            return View(activity);
        }
    }
}
