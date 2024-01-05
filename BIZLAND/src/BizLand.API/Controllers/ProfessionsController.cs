using BizLand.Business.DTOs.ProfessionDTOs;
using BizLand.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizLand.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionsController : ControllerBase
    {
        private readonly IProfessionService _professionService;

        public ProfessionsController(IProfessionService professionService)
        {
            _professionService = professionService;
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateProfession([FromForm]CreateProfessionDTO professionDTO)
        {
            try
            {
                await _professionService.CreateAsync(professionDTO);
            }
            catch (Exception ex) { }
            return StatusCode(201);
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateProfession([FromForm] UpdateProfessionDTO professionDTO)
        {
            try
            {
                await _professionService.UpdateAsync(professionDTO);
            }
            catch (Exception ex) { }
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetProfession()
        {
            var professionDTO = await _professionService.GetAllAsync();
            return Ok(professionDTO);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfession(int id)
        {
            var professionDTO = await _professionService.GetByIdAsync(id);
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
                await _professionService.SoftDelete(id);
            }
            catch (Exception ex) { }
            return StatusCode(204);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public  async Task<IActionResult> DeleteProfession(int id)
        {
            try
            {
              await  _professionService.DeleteAsync(id);
            }
            catch(Exception ex) { } 
            return Ok();
            
        }
    }
}
