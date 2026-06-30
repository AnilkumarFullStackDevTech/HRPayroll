using HRPayroll.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRPayroll.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly HRPayrollDbContext _context;

        public DatabaseController(HRPayrollDbContext context)
        {
            _context = context;
        }

        [HttpGet("departments")]
        public IActionResult GetDepartments()
        {
            return Ok(_context.Departments.ToList());
        }
    }
}
