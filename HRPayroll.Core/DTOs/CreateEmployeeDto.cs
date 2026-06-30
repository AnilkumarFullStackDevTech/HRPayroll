using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPayroll.Core.DTOs
{
    public class CreateEmployeeDto
    {
        public string EmployeeName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public DateOnly JoinDate { get; set; }

        public int DepartmentId { get; set; }
    }
}
