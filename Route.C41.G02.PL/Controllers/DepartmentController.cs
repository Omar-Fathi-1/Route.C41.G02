using Microsoft.AspNetCore.Mvc;
using Route.C41.G02.BLL.Interfaces;
using Route.C41.G02.BLL.Repositories;

namespace Route.C41.G02.PL.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IDepartmentRepository _DepartmentRepository;
        public DepartmentController(DepartmentRepository DepartmentRepository)
        {
            _DepartmentRepository = DepartmentRepository;
        }
        public IActionResult Index()
        {
            var Departments = _DepartmentRepository.GetAll();
            return View(Departments);
        }
    }
}
