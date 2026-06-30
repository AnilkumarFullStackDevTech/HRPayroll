using HRPayroll.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPayroll.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetAllAsync();

        Task<DepartmentDto?> GetByIdAsync(int id);

        Task AddAsync(CreateDepartmentDto dto);

        Task UpdateAsync(int id, CreateDepartmentDto dto);

        Task DeleteAsync(int id);
    }
}
