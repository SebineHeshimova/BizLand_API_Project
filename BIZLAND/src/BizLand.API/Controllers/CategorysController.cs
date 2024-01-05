using BizLand.Business.DTOs.CategoryDTOs;
using BizLand.Business.DTOs.CategoryDTOs;
using BizLand.Business.Services.Implementations;
using BizLand.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizLand.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly ICategoryServise _categoryServise;

        public CategorysController(ICategoryServise categoryServise)
        {
            _categoryServise = categoryServise;
        }
        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateCategory([FromForm] CreateCategoryDTO categoryDTO)
        {
            try
            {
                await _categoryServise.CreateAsync(categoryDTO);
            }
            catch (Exception ex) { }
            return StatusCode(201);
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateCategory([FromForm] UpdateCategoryDTO categoryDTO)
        {
            try
            {
                await _categoryServise.UpdateAsync(categoryDTO);
            }
            catch (Exception ex) { }
            return NoContent();
        }
        [Authorize(Roles ="User")]
        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            var categoryDTO = await _categoryServise.GetAllAsync();
            return Ok(categoryDTO);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var categoryDTO = await _categoryServise.GetByIdAsync(id);
            return Ok(categoryDTO);
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPatch("SoftDelete/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> SoftDeleteCategory(int id)
        {
            try
            {
                await _categoryServise.SoftDelete(id);
            }
            catch (Exception ex) { }
            return StatusCode(204);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _categoryServise.DeleteAsync(id);
            }
            catch (Exception ex) { }
            return Ok();

        }
    }
}
