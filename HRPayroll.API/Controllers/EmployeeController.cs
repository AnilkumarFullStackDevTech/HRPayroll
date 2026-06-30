using HRPayroll.Core.DTOs;
using HRPayroll.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRPayroll.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _service.GetByIdAsync(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeDto dto)
        {
            await _service.AddAsync(dto);

            return Ok("Employee Created Successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateEmployeeDto dto)
        {
            await _service.UpdateAsync(id, dto);

            return Ok("Employee Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok("Employee Deleted Successfully");
        }
    }
}