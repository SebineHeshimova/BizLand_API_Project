using AutoMapper;
using BizLand.Business.DTOs.EmployeeDTOs;
using BizLand.Business.DTOs.ProfessionDTOs;
using BizLand.Business.Extensions;
using BizLand.Business.Services.Interfaces;
using BizLand.Core.Entity;
using BizLand.Core.Repositories.Interfaces;
using BizLand.Data.Repositories.Implementations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;


namespace BizLand.Business.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        IWebHostEnvironment _env;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _env = env;
        }

        public DbSet<Employee> Table => throw new NotImplementedException();

        public async Task CreateAsync(CreateEmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            employee.ImageUrl = Helper.SaveFile(_env.WebRootPath, "uploads/employees", employeeDTO.ImageFile);
            employee.CreatedDate = DateTime.UtcNow.AddHours(4);
            employee.UpdatedDate = DateTime.UtcNow.AddHours(4);
            employee.IsDeleted = false;
            await _employeeRepository.CreateAsync(employee);
            await _employeeRepository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(x => x.Id == id);
            if (employee == null) throw new Exception();
            string deletePath = Path.Combine(_env.WebRootPath, "uploads/employees", employee.ImageUrl);

            if (System.IO.File.Exists(deletePath))
            {
                System.IO.File.Delete(deletePath);
            }
            _employeeRepository.Delete(employee);
            await _employeeRepository.CommitAsync();
        }

        public IQueryable<Employee> GetQueryable()
        {
            throw new NotImplementedException();
        }

        public async Task SoftDelete(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(x => x.Id == id);
            if (employee == null) throw new Exception();
            employee.IsDeleted = !employee.IsDeleted;
            employee.UpdatedDate = DateTime.UtcNow.AddHours(5);
            await _employeeRepository.CommitAsync();
        }

        public async Task Update(UpdateEmployeeDTO employeeDTO)
        {
            var employee = await _employeeRepository.GetByIdAsync(x => x.Id == employeeDTO.Id);
            if (employee == null) throw new Exception();


            if(employeeDTO.ImageFile != null)
            {
                string deletePath = Path.Combine(_env.WebRootPath, "uploads/employees", employee.ImageUrl);

                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }

                employee.ImageUrl = Helper.SaveFile(_env.WebRootPath, "uploads/employees", employeeDTO.ImageFile);
            }
            employee = _mapper.Map(employeeDTO, employee);
           

            employee.UpdatedDate = DateTime.UtcNow.AddHours(4);
            await _employeeRepository.CommitAsync();
        }

        public async Task<List<GetEmployeeDTO>> GetAllAsync(string? value, int? professionId, int? values)
        {
            IQueryable<Employee> employees = _employeeRepository.Table.Where(x => x.IsDeleted == false).AsQueryable();
            if (employees == null) throw new Exception();
            if (value != null)
            {
                employees = employees.Where(x => x.FullName.ToLower().Contains(value.ToLower().Trim()));
            }
            if (professionId != null)
            {
                employees = employees.Where(x => x.ProfessionId == professionId);
            }
            if (values != null)
            {
                switch (values)
                {
                    case 1:
                        employees = employees.OrderBy(x => x.CreatedDate);
                        break;
                    case 2:
                        employees = employees.OrderBy(x => x.FullName);
                        break;
                    default: throw new Exception();
                }
            }
            var employeeDTOs = employees.Select(x => new GetEmployeeDTO()
            {
                FullName = x.FullName,
                ProfessionId= x.ProfessionId,
                InstagramUrl = x.InstagramUrl,
                FacebookUrl = x.FacebookUrl,
                TwitterUrl = x.TwitterUrl,
                LinkedInUrl = x.LinkedInUrl
            });
            return employeeDTOs.ToList();

        }

        public async Task<GetEmployeeDTO> GetByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(x => x.Id == id);
            if (employee == null) throw new Exception();
            GetEmployeeDTO employeeDTO = _mapper.Map<GetEmployeeDTO>(employee);
            return employeeDTO;
        }
    }
}
