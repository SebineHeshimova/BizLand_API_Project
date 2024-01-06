using BizLand.Business.DTOs.EmployeeDTOs;
using BizLand.Business.DTOs.ProfessionDTOs;
using BizLand.Business.Services.Implementations;
using BizLand.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizLand.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateEmployee([FromForm] CreateEmployeeDTO employeeDTO)
        {
            try
            {
                await _employeeService.CreateAsync(employeeDTO);
            }
            catch (Exception ex) { }
            return StatusCode(201);
        }
        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateEmployee([FromForm] UpdateEmployeeDTO employeeDTO)
        {
            try
            {
                await _employeeService.Update(employeeDTO);
            }
            catch (Exception ex) { }
            return NoContent();
        }

        [Authorize(Roles = "SuperAdmin, Admin, User")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee(string? value, int? professionId, int? values)
        {
            var professionDTO = await _employeeService.GetAllAsync(value, professionId, values);
            return Ok(professionDTO);
        }

        [Authorize(Roles ="SuperAdmin, Admin, User")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var professionDTO = await _employeeService.GetByIdAsync(id);
            return Ok(professionDTO);
        }
        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPatch("SoftDelete/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> SoftDeleteProfession(int id)
        {
            try
            {
                await _employeeService.SoftDelete(id);
            }
            catch (Exception ex) { }
            return StatusCode(204);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteProfession(int id)
        {
            try
            {
                await _employeeService.DeleteAsync(id);
            }
            catch (Exception ex) { }
            return Ok();

        }


    }
}
