using AuditingSystem.Entities.AuditProcess;
using AuditingSystem.Entities.Setup;
using AuditingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AuditingSystem.Web.Controllers.AuditProcess
{
    public class CompanyController : Controller
    {
        private readonly IBaseRepository<Company, int> _companyRepository;
        private readonly IBaseRepository<Industry, int> _industryRepository;
        public CompanyController(
            IBaseRepository<Company, int> companyRepository,
            IBaseRepository<Industry, int> industryRepository)
        {
            _companyRepository = companyRepository;
            _industryRepository = industryRepository;
        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var companies = await _companyRepository.ListAsync(
                  c => c.IsDeleted == false,
                  q => q.OrderBy(u => u.Id),
                  c => c.Industry);

            var model = companies.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.TotalRow = companies.Count();
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling(companies.Count() / (double)pageSize);

            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            var industry = _industryRepository.ListAsync(
                  u => u.IsDeleted == false,
                  q => q.OrderBy(u => u.Id),
                  null).Result;

            ViewBag.IndustryId = new SelectList(industry, "Id", "Name");

            return View();
        }


        public async Task<IActionResult> Edit(int id)
        {
            var company = await _companyRepository.FindByAsync(id);

            var industry = _industryRepository.ListAsync(
                  u => u.IsDeleted == false,
                  q => q.OrderBy(u => u.Id),
                  null).Result;

            ViewBag.IndustryId = new SelectList(industry, "Id", "Name", company.IndustryId);

            return View(company);
        }


    }
}
