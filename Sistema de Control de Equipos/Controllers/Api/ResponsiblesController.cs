using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Control_de_Equipos.Models;

namespace Sistema_de_Control_de_Equipos.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsiblesController : ControllerBase
    {
        private readonly ComputerManagementContext _context;
        public ResponsiblesController(ComputerManagementContext context)
        {
            _context = context;
        }

        public async Task<List<Responsible>> Get()
        {
            return await _context.Responsibles.ToListAsync();
        }
    }
}
