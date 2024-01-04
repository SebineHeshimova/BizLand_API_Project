using BizLand.Business.DTOs.FeatureDTOs;
using BizLand.Business.Services.Implementations;
using BizLand.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizLand.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeaturesController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateFeature([FromForm] CreateFeatureDTO featuresDTO)
        {
            try
            {
                await _featureService.CreateAsync(featuresDTO);
            }
            catch (Exception ex) { }
            return StatusCode(201);
        }
        [HttpPut("")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateFeature([FromForm]UpdateFeatureDTO featureDTO)
        {
            try
            {
                await _featureService.UpdateAsync(featureDTO);
            }
            catch (Exception ex) { }
            return NoContent();
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllFeature()
        {
            var featureDTO = await _featureService.GetAllAsync();
            return Ok(featureDTO);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            var featureDTO = await _featureService.GetByIdAsync(id);
            return Ok(featureDTO);
        }
        [HttpDelete("SoftDelete/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> SoftDeleteFeature(int id)
        {
            try
            {
                await _featureService.SoftDelete(id);
            }
            catch (Exception ex) { }
            return StatusCode(204);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            try
            {
                await _featureService.DeleteAsync(id);
            }
            catch (Exception ex) { }
            return Ok();

        }

    }
}
