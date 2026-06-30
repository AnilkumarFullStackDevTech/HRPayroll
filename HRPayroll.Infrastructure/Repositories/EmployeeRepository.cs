using HRPayroll.Core.Entities;
using HRPayroll.Infrastructure.Context;
using HRPayroll.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HRPayroll.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HRPayrollDbContext _context;

        public EmployeeRepository(HRPayrollDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees
                .Include(x => x.Department)
                .OrderBy(x => x.EmployeeName)
                .ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees
                .Include(x => x.Department)
                .FirstOrDefaultAsync(x => x.EmployeeId == id);
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }

        public Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Employee employee)
        {
            _context.Employees.Remove(employee);
            return Task.CompletedTask;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}