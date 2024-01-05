using AutoMapper;
using BizLand.Business.DTOs.PortfolioDTOs;
using BizLand.Business.Extensions;
using BizLand.Business.Services.Interfaces;
using BizLand.Core.Entity;
using BizLand.Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.Services.Implementations
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public PortfolioService(IPortfolioRepository portfolioRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
            _env = env;
        }

        public async Task CreateAsync(CreatePortfolioDTO portfolioDTO)
        {
            IFormFile files=null;
            var portfolio = _mapper.Map<Portfolio>(portfolioDTO);
            portfolio.ImageUrl = Helper.SaveFile(_env.WebRootPath, "uploads/portfolios", portfolioDTO.ImageFile);
            if(portfolioDTO.ImageFiles != null)
            {
                foreach(var file in portfolioDTO.ImageFiles)
                {
                    files = file;
                }
            }

            await _portfolioRepository.CreateAsync(portfolio);
            await _portfolioRepository.CommitAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetPortfolioDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetPortfolioDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UpdatePortfolioDTO portfolioDTO)
        {
            throw new NotImplementedException();
        }
    }
}
