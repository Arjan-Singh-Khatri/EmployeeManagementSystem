using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllEmployees();
            return View(employees);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeModel employee)
        {
            await _employeeService.AddEmployee(employee);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employees = await _employeeService.GetAllEmployees();
            var emp = employees.FirstOrDefault(e => e.Id == id);
            return View(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeModel employee)
        {
            await _employeeService.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
