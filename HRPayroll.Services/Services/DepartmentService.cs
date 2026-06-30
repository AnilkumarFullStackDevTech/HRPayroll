using AutoMapper;
using HRPayroll.Core.DTOs;
using HRPayroll.Core.Entities;
using HRPayroll.Infrastructure.Interfaces;
using HRPayroll.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPayroll.Services.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository repository,
                                 IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<DepartmentDto>> GetAllAsync()
        {
            var departments = await _repository.GetAllAsync();

            return _mapper.Map<List<DepartmentDto>>(departments);
        }

        public async Task<DepartmentDto?> GetByIdAsync(int id)
        {
            var department = await _repository.GetByIdAsync(id);

            if (department == null)
                return null;

            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task AddAsync(CreateDepartmentDto dto)
        {
            var department = _mapper.Map<Department>(dto);

            await _repository.AddAsync(department);

            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(int id, CreateDepartmentDto dto)
        {
            var department = await _repository.GetByIdAsync(id);

            if (department == null)
                throw new Exception("Department Not Found");

            department.DepartmentName = dto.DepartmentName;

            await _repository.UpdateAsync(department);

            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var department = await _repository.GetByIdAsync(id);

            if (department == null)
                throw new Exception("Department Not Found");

            await _repository.DeleteAsync(department);

            await _repository.SaveAsync();
        }
    }
}
