using BizLand.Business.DTOs.PortfolioDTOs;
using BizLand.Business.DTOs.ProfessionDTOs;
using BizLand.Core.Entity;
using BizLand.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.Services.Interfaces
{
    public interface IPortfolioService
    {
        Task CreateAsync(CreatePortfolioDTO portfolioDTO);
        Task UpdateAsync(UpdatePortfolioDTO portfolioDTO);
        Task DeleteAsync(int id);
        Task SoftDelete(int id);
        Task<GetPortfolioDTO> GetByIdAsync(int id);
        Task<List<GetPortfolioDTO>> GetAllAsync();
    }
}
