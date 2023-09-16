using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Control_de_Equipos.Models.ViewModels;
using Sistema_de_Control_de_Equipos.Models;

namespace Sistema_de_Control_de_Equipos.Controllers
{
    public class ProblemsController : Controller
    {
        private ComputerManagementContext _context;
        public ProblemsController(ComputerManagementContext context)
        {
            _context = context;
        }
        public IActionResult Create(DetailsViewModel model)
        {
            if(model.Description != null)
            {            
                Problem problem = new Problem()
                {
                    Description = model.Description,
                    PcId = model.PcId,
             
                };

                _context.Problems.Add(problem);
                _context.SaveChanges();
            }

            return RedirectToAction("details", "computers", new { id = model.PcSerial });

        }

        public IActionResult Delete(int id, string pcSerial)
        {
            Problem problem = _context.Problems.Find(id);
            if (problem != null)
            {
                _context.Problems.Remove(problem);

                _context.SaveChanges();

            }

            return RedirectToAction("details", "computers", new { id = pcSerial });
        }
    }
}
