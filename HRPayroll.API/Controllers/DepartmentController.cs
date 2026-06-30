using HRPayroll.Core.DTOs;
using HRPayroll.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRPayroll.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
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
            var data = await _service.GetByIdAsync(id);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentDto dto)
        {
            await _service.AddAsync(dto);

            return Ok("Department Created Successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,
                                                CreateDepartmentDto dto)
        {
            await _service.UpdateAsync(id, dto);

            return Ok("Department Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok("Department Deleted Successfully");
        }
    }
}