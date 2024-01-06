using BizLand.Business.DTOs.PortfolioDTOs;
using BizLand.Business.Services.Implementations;
using BizLand.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Resources;

namespace BizLand.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfoliosController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;

        public PortfoliosController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreatePortfolio([FromForm] CreatePortfolioDTO portfolioDTO)
        {
            try
            {
                await _portfolioService.CreateAsync(portfolioDTO);
            }
            catch (Exception ex) { }
            return StatusCode(201);
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPut("")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdatePortfolio([FromForm]UpdatePortfolioDTO portfolioDTO)
        {
            try
            {
                await _portfolioService.UpdateAsync(portfolioDTO);
            }
            catch (Exception ex) { }
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPortfolio()
        {

            var portfolio = await _portfolioService.GetAllAsync();
            return Ok(portfolio);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolio(int id)
        {
            var portfolio = await _portfolioService.GetByIdAsync(id);
            return Ok(portfolio);
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPatch("SoftDelete/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> SoftDeletePortfolio(int id)
        {
            try
            {
                await _portfolioService.SoftDelete(id);
            }
            catch (Exception ex) { }
            return StatusCode(204);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletePortfolio(int id)
        {
            try
            {
                await _portfolioService.DeleteAsync(id);
            }
            catch (Exception ex) { }
            return StatusCode(204);
        }
    }
}
