using Microsoft.AspNetCore.Mvc;
using Route.C41.G02.BLL.Interfaces;
using Route.C41.G02.DAL.Models;
using Route.C41.G02.BLL.Repositories;
using System;
namespace Route.C41.G02.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        public EmployeeController(IEmployeeRepository EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Employees = _EmployeeRepository.GetAll();
            return View(Employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee Employee)
        {
            if (ModelState.IsValid)
            {
                var count = _EmployeeRepository.Add(Employee);
                if (count > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(Employee);
        }
        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (!id.HasValue)
                return BadRequest();
            var Employee = _EmployeeRepository.Get(id.Value);
            if (Employee is null)
                return NotFound();
            return View(Employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();
            var Employee = _EmployeeRepository.Get(id.Value);
            if (Employee is null)
                return NotFound();
            return View(Employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Employee Employee)
        {
            if (id != Employee.Id)
                return BadRequest();
            if (ModelState.IsValid) // server side Validation [chick validation]
            {
                try
                {
                    _EmployeeRepository.Update(Employee);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // 1. Log Exeption
                    // 2. Friendly Message
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(Employee);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete([FromRoute] int id, Employee Employee)
        {
            if (id != Employee.Id)
            {
                return BadRequest();
            }
            try
            {
                _EmployeeRepository.Delete(Employee);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(Employee);
        }
    }

}

