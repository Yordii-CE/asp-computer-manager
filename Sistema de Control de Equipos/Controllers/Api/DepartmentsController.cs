using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Control_de_Equipos.Models;

namespace Sistema_de_Control_de_Equipos.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ComputerManagementContext _context;
        public DepartmentsController(ComputerManagementContext context)
        {
            _context = context;
        }

        public List<Department> Get()
        {
            return _context.Departments.ToList();
        }
    }
}
