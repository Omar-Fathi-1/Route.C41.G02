using Microsoft.AspNetCore.Mvc;
using Route.C41.G02.BLL.Interfaces;
using Route.C41.G02.BLL.Repositories;
using Route.C41.G02.DAL.Models;

namespace Route.C41.G02.PL.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IDepartmentRepository _DepartmentRepository;
        public DepartmentController(IDepartmentRepository DepartmentRepository)
        {
            _DepartmentRepository = DepartmentRepository;
        }
        public IActionResult Index()
        {
            var Departments = _DepartmentRepository.GetAll();
            return View(Departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                var count = _DepartmentRepository.Add(department);
                if(count > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var department = _DepartmentRepository.Get(id.Value);
            if (department is null)
                return NotFound();
            return View(department);
        }

    }
}
