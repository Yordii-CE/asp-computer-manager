using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Control_de_Equipos.Models;
using Sistema_de_Control_de_Equipos.Models.ViewModels;

namespace Sistema_de_Control_de_Equipos.Controllers
{
    public class ModelsController : Controller
    {
        private ComputerManagementContext _context;

        public ModelsController(ComputerManagementContext context) {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ModelViewModel model = new ModelViewModel();
            var models = await _context.Models.ToListAsync();
            model.Models = models;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ModelViewModel model)
        {
            if(ModelState.IsValid)
            {
                var m = new Model()
                {
                    Name = model.Name

                };

                _context.Add(m);
                await  _context.SaveChangesAsync();
                return RedirectToAction("index");
                
            }
            return Redirect("index");
        }

        public async Task<IActionResult> Edit(ModelViewModel model)
        {
            if (ModelState.IsValid)
            {
                var m = _context.Models.First(el=>el.Id == model.Id);
                m.Name = model.Name;
                
                await _context.SaveChangesAsync();
                return RedirectToAction("index");

            }
            return Redirect("index");
        }
    }
}
