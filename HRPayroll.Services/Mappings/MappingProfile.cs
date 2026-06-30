using AutoMapper;
using HRPayroll.Core.DTOs;
using HRPayroll.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPayroll.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();

            CreateMap<CreateDepartmentDto, Department>();

            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.DepartmentName,
                opt => opt.MapFrom(src => src.Department.DepartmentName));

            CreateMap<CreateEmployeeDto, Employee>();
        }
    }
}
