using Microsoft.AspNetCore.Mvc;
using Sistema_de_Control_de_Equipos.Models.ViewModels;
using Sistema_de_Control_de_Equipos.Models;
using Microsoft.EntityFrameworkCore;

namespace Sistema_de_Control_de_Equipos.Controllers
{
    public class ResponsiblesController : Controller
    {
        private readonly ComputerManagementContext _context;
        public ResponsiblesController(ComputerManagementContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ResponsibleViewModel model = new ResponsibleViewModel();
            var responsibles = await _context.Responsibles.ToListAsync();
            model.Responsibles = responsibles;

            return View(model);
        }

        public IActionResult Create(ResponsibleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var responsible = new Responsible()
                {
                    Name = model.Name
                };

                _context.Responsibles.Add(responsible);
                _context.SaveChanges();
            }
            return Redirect("Index");
        }
        public async Task<IActionResult> Edit(ResponsibleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var responsible = _context.Responsibles.First(el => el.Id == model.Id);
                responsible.Name = model.Name;

                await _context.SaveChangesAsync();
                return RedirectToAction("index");

            }
            return Redirect("index");
        }
    }
}
