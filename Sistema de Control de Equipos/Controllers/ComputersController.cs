using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Control_de_Equipos.Models;
using Sistema_de_Control_de_Equipos.Models.ViewModels;
using System.Diagnostics;


namespace Sistema_de_Control_de_Equipos.Controllers
{
    public class ComputersController : Controller
    {
        private ComputerManagementContext _context;
        public ComputersController(ComputerManagementContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            PcViewModel model = new PcViewModel();

            var pcs = _context.Pcs
                .Include(pc=>pc.Department)
                .Include(pc=>pc.Responsible);

            ViewData["Departments"] = new SelectList(_context.Departments, "Id", "Name");
            ViewData["Responsibles"] = new SelectList(_context.Responsibles, "Id", "Name");

            model.Pcs = await pcs.ToListAsync();

            return View(model);
        }

        public IActionResult Details(string id)
        {
            string serial = id;
            var pc = _context.Pcs.Where(pc => pc.Serial == serial)
                .Include(pc=>pc.Department)
                .Include(pc => pc.Responsible).First();

            ViewBag.Serial = serial;
            ViewData["Pc"] = pc;
            ViewData["Brands"] = new SelectList(_context.Brands, "Id", "Name");
            ViewData["Models"] = new SelectList(_context.Models, "Id", "Name");


            var pcComponents = (from component in _context.Components
                join brand in _context.Brands on component.BrandId equals brand.Id
                join modelo in _context.Models on component.ModelId equals modelo.Id
                where component.Pc.Serial == serial
                select new { Component = component, Brand = brand, Model = modelo }).ToList<dynamic>();

            var pcProblems = _context.Problems.Where(problem=>problem.PcId == pc.Id).ToList<dynamic>();
            DetailsViewModel model = new DetailsViewModel();
            model.Components = pcComponents;
            model.Problems = pcProblems;

            return View(model);
        }

        public IActionResult Create(PcViewModel model)
        {
            if (ModelState.IsValid)
            {
                Pc pc = new Pc()
                {
                    Serial = model.Serial,
                    ResponsibleId = model.ResponsibleId,
                    DepartmentId = model.DepartmentId,
                    Owner = model.Owner,
                    Observations = model.Observations,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
            };

                _context.Pcs.Add(pc);
                _context.SaveChanges();


            }

            return Redirect("Index");
        }

        public IActionResult Edit(PcViewModel model, int id)
        {
            if (ModelState.IsValid)
            {
                Pc pc = _context.Pcs.Find(id);

                if (pc != null)
                {
                    pc.Serial = model.Serial;
                    pc.ResponsibleId = model.ResponsibleId;
                    pc.DepartmentId = model.DepartmentId;
                    pc.Owner = model.Owner;
                    pc.Observations = model.Observations;
                    pc.DateUpdated = DateTime.Now;
                
                    _context.SaveChanges();

                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Pc pc = _context.Pcs.Find(id);
       
            if (pc != null)
            {
                _context.Pcs.Remove(pc);
                _context.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}