using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Control_de_Equipos.Models;
using Sistema_de_Control_de_Equipos.Models.ViewModels;
using System.ComponentModel;
using Component = Sistema_de_Control_de_Equipos.Models.Component;

namespace Sistema_de_Control_de_Equipos.Controllers
{
    public class ComponentsController : Controller
    {
        private ComputerManagementContext _context;
        public ComponentsController(ComputerManagementContext context)
        {
            _context = context;
        }
        public IActionResult Create(DetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                Component component = new Component()
                {
                    Serial = model.Serial,
                    Name = model.Name,
                    Specification = model.Specification,
                    BrandId = model.BrandId,
                    ModelId = model.ModelId,
                    PcId = model.PcId
                };

                _context.Components.Add(component);
                _context.SaveChanges();


            }     

            return RedirectToAction("details", "computers", new { id = model.PcSerial });
        }

        public IActionResult Edit(DetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                Component component = _context.Components.Find(model.Id);
                if (component != null)
                {
                    component.Serial = model.Serial;
                    component.Name = model.Name;
                    component.Specification = model.Specification;
                    component.BrandId = model.BrandId;
                    component.ModelId = model.ModelId;
                    component.PcId = model.PcId;

                    _context.SaveChanges();

                }
            }
            return RedirectToAction("details", "computers", new { id = model.PcSerial });
        }

        public IActionResult Delete(DetailsViewModel model,  int id)
        {            
            Component component = _context.Components.Find(id);
            if (component != null)
            {
                _context.Components.Remove(component);

                _context.SaveChanges();

            }
         
            return RedirectToAction("details", "computers", new { id = model.PcSerial });
        }
    }
}
