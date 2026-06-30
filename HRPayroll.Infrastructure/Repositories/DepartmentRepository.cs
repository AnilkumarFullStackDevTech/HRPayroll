using HRPayroll.Core.Entities;
using HRPayroll.Infrastructure.Context;
using HRPayroll.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPayroll.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly HRPayrollDbContext _context;

        public DepartmentRepository(HRPayrollDbContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.Departments
                .OrderBy(x => x.DepartmentName)
                .ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await _context.Departments
                .FirstOrDefaultAsync(x => x.DepartmentId == id);
        }

        public async Task AddAsync(Department department)
        {
            await _context.Departments.AddAsync(department);
        }

        public Task UpdateAsync(Department department)
        {
            _context.Departments.Update(department);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Department department)
        {
            _context.Departments.Remove(department);
            return Task.CompletedTask;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
