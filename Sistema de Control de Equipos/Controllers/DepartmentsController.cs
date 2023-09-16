using Microsoft.AspNetCore.Mvc;
using Sistema_de_Control_de_Equipos.Models.ViewModels;
using Sistema_de_Control_de_Equipos.Models;
using Microsoft.EntityFrameworkCore;

namespace Sistema_de_Control_de_Equipos.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly ComputerManagementContext _context;
        public DepartmentsController(ComputerManagementContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            DepartmentViewModel model = new DepartmentViewModel();
            var departments = await _context.Departments.ToListAsync();
            model.Departments = departments;

            return View(model);
        }

        public IActionResult Create(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var department = new Department()
                {
                    Name = model.Name
                };

                _context.Departments.Add(department);
                _context.SaveChanges();
            }
            return Redirect("Index");
        }
        public async Task<IActionResult> Edit(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var department = _context.Departments.First(el => el.Id == model.Id);
                department.Name = model.Name;

                await _context.SaveChangesAsync();
                return RedirectToAction("index");

            }
            return Redirect("index");
        }
    }
}
