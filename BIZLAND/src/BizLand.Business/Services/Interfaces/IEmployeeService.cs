using BizLand.Business.DTOs.EmployeeDTOs;
using BizLand.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.Services.Interfaces
{
    public interface IEmployeeService
    {
        DbSet<Employee> Table { get; }
        Task CreateAsync(CreateEmployeeDTO employeeDTO);
        Task Update(UpdateEmployeeDTO employeeDTO);
        Task DeleteAsync(int id);
        Task SoftDelete(int id);
        IQueryable<Employee> GetQueryable();
        Task<GetEmployeeDTO> GetByIdAsync(int id);
        Task<List<GetEmployeeDTO>> GetAllAsync(string? value, int? professionId, int? order);
    }
}
