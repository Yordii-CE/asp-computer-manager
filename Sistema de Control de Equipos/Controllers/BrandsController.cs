using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Control_de_Equipos.Models;
using Sistema_de_Control_de_Equipos.Models.ViewModels;

namespace Sistema_de_Control_de_Equipos.Controllers
{
    public class BrandsController : Controller
    {
        private readonly ComputerManagementContext _context;
        public BrandsController(ComputerManagementContext context) 
        { 
            _context = context;    
        }
        public async Task<IActionResult> Index()
        {
            BrandViewModel model = new BrandViewModel();
            var brands = await _context.Brands.ToListAsync();
            model.Brands = brands;

            return View(model);
        }

        public IActionResult Create(BrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                var brand = new Brand()
                {
                    Name = model.Name 
                };

               _context.Brands.Add(brand);
                _context.SaveChanges();    
            }
            return Redirect("Index");
        }
        public async Task<IActionResult> Edit(BrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                var m = _context.Brands.First(el => el.Id == model.Id);
                m.Name = model.Name;

                await _context.SaveChangesAsync();
                return RedirectToAction("index");

            }
            return Redirect("index");
        }
    }
}
