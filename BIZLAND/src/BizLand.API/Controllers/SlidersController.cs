using BizLand.Business.DTOs.FeatureDTOs;
using BizLand.Business.DTOs.SliderDTOs;
using BizLand.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizLand.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SlidersController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateSlider([FromForm] CreateSliderDTO sliderDTO)
        {
            try
            {
                await _sliderService.CreateAsync(sliderDTO);
            }
            catch (Exception ex) { }
            return StatusCode(201);
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPut("")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateSlider([FromForm] UpdateSliderDTO sliderDTO)
        {
            try
            {
                await _sliderService.UpdateAsync(sliderDTO);
            }
            catch (Exception ex) { }
            return NoContent();
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllSlider()
        {
            var sliderDTOs = await _sliderService.GetAllAsync();
            return Ok(sliderDTOs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSlider(int id)
        {
            var sliderDTO = await _sliderService.GetByIdAsync(id);
            return Ok(sliderDTO);
        }
        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPatch("SoftDelete/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> SoftDeleteSlider(int id)
        {
            try
            {
                await _sliderService.SoftDelete(id);
            }
            catch (Exception ex) { }
            return StatusCode(204);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            try
            {
                await _sliderService.DeleteAsync(id);
            }
            catch (Exception ex) { }
            return Ok();

        }
    }
}
