using HRPayroll.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPayroll.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllAsync();

        Task<EmployeeDto?> GetByIdAsync(int id);

        Task AddAsync(CreateEmployeeDto dto);

        Task UpdateAsync(int id, CreateEmployeeDto dto);

        Task DeleteAsync(int id);
    }
}
