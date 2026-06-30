using AutoMapper;
using HRPayroll.Core.DTOs;
using HRPayroll.Core.Entities;
using HRPayroll.Infrastructure.Interfaces;
using HRPayroll.Services.Interfaces;

namespace HRPayroll.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository,
                               IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            var employees = await _repository.GetAllAsync();

            return _mapper.Map<List<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);

            if (employee == null)
                return null;

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task AddAsync(CreateEmployeeDto dto)
        {
            var employee = _mapper.Map<Employee>(dto);

            await _repository.AddAsync(employee);

            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(int id, CreateEmployeeDto dto)
        {
            var employee = await _repository.GetByIdAsync(id);

            if (employee == null)
                throw new Exception("Employee Not Found");

            employee.EmployeeName = dto.EmployeeName;
            employee.Email = dto.Email;
            employee.Salary = dto.Salary;
            employee.JoinDate = DateTime.Now;
            employee.DepartmentId = dto.DepartmentId;

            await _repository.UpdateAsync(employee);

            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);

            if (employee == null)
                throw new Exception("Employee Not Found");

            await _repository.DeleteAsync(employee);

            await _repository.SaveAsync();
        }
    }
}