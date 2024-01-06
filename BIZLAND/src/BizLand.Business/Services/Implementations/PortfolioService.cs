using AutoMapper;
using AutoMapper.Features;
using BizLand.Business.DTOs.FeatureDTOs;
using BizLand.Business.DTOs.PortfolioDTOs;
using BizLand.Business.Extensions;
using BizLand.Business.Services.Interfaces;
using BizLand.Core.Entity;
using BizLand.Core.Repositories.Interfaces;
using BizLand.Data.Migrations;
using BizLand.Data.Repositories.Implementations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        private readonly IPortfolioImageRepository _portfolioImageRepository;
        private readonly ICategoryRepository _categoryRepository;
        public PortfolioService(IPortfolioRepository portfolioRepository, IMapper mapper, IWebHostEnvironment env, IPortfolioImageRepository portfolioImageRepository, ICategoryRepository categoryRepository)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
            _env = env;
            _portfolioImageRepository = portfolioImageRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task CreateAsync(CreatePortfolioDTO portfolioDTO)
        {
            if (!_categoryRepository.Table.Any(x => x.Id == portfolioDTO.CategoryId)) throw new Exception();
            Portfolio portfolio = _mapper.Map<Portfolio>(portfolioDTO);

            portfolio.ImageUrl = Helper.SaveFile(_env.WebRootPath, "uploads/portfolios", portfolioDTO.ImageFile);
            PortfolioImage portfolioImage = new PortfolioImage
            {
                ImageUrl = portfolio.ImageUrl,
                Portfolio = portfolio,
            };
            await _portfolioImageRepository.CreateAsync(portfolioImage);


            if (portfolioDTO.ImageFiles != null)
            {
                foreach (var image in portfolioDTO.ImageFiles)
                {
                    string newImageUrl = Helper.SaveFile(_env.WebRootPath, "uploads/portfolios", image);
                    PortfolioImage portfolioImage1 = new PortfolioImage
                    {
                        ImageUrl = newImageUrl,
                        Portfolio = portfolio,
                    };
                    await _portfolioImageRepository.CreateAsync(portfolioImage1);
                }
            }


            portfolio.CreatedDate = DateTime.UtcNow.AddHours(4);
            portfolio.UpdatedDate = DateTime.UtcNow.AddHours(4);
            portfolio.IsDeleted = false;
            await _portfolioRepository.CreateAsync(portfolio);
            await _portfolioRepository.CommitAsync();
        }

        public async Task UpdateAsync(UpdatePortfolioDTO portfolioDTO)
        {
            var portfolio = await _portfolioRepository.GetByIdAsync(p => p.Id == portfolioDTO.Id, "Images");
            if (portfolio == null) throw new Exception();
            if (portfolioDTO.ImageFiles != null)
            {
                portfolio.Images.RemoveAll(p => !portfolioDTO.PortfolioImageIds.Contains(p.Id));

                foreach (var image in portfolioDTO.ImageFiles)
                {
                    string deletePath = Path.Combine(_env.WebRootPath, "uploads/portfolios", portfolio.ImageUrl);

                    if (System.IO.File.Exists(deletePath))
                    {
                        System.IO.File.Delete(deletePath);
                    }

                    portfolio.ImageUrl = Helper.SaveFile(_env.WebRootPath, "uploads/portfolios", image);
                    PortfolioImage portfolioImage = new PortfolioImage
                    {
                        ImageUrl = portfolio.ImageUrl,
                        Portfolio = portfolio
                    };
                    portfolio.Images.Add(portfolioImage);
                }
            }
            else
            {
                throw new Exception();
            }
            portfolio = _mapper.Map(portfolioDTO, portfolio);
            portfolio.UpdatedDate= DateTime.UtcNow.AddHours(4);
            await _portfolioRepository.CommitAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var portfolio = await _portfolioRepository.GetByIdAsync(x => x.Id == id, "Images");
            if (portfolio == null) throw new Exception();
            foreach (var portfolioImage in portfolio.Images)
            {
                string deletePath = Path.Combine(_env.WebRootPath, "uploads/portfolios", portfolioImage.ImageUrl);

                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }
            }
            _portfolioRepository.Delete(portfolio);
            await _portfolioRepository.CommitAsync();
        }

        public async Task<List<GetPortfolioDTO>> GetAllAsync()
        {
            List<Portfolio> portfolios = await _portfolioRepository.GetAllAsync(p => p.IsDeleted == false, "Category");
            IEnumerable<GetPortfolioDTO> portfolioDTOs = new List<GetPortfolioDTO>();
            portfolioDTOs = portfolios.Select(p => new GetPortfolioDTO
            {
                Title = p.Title,
                Description = p.Description,
                CategoryId = p.CategoryId,
                Client = p.Client,
                ProjectDate = p.ProjectDate,
                ProjectURL = p.ProjectURL,
                CategoryName = p.Category.Name
            });
            return portfolioDTOs.ToList();
        }

        public async Task<GetPortfolioDTO> GetByIdAsync(int id)
        {
            var portfolio = await _portfolioRepository.GetByIdAsync(f => f.Id == id, "Category");
            if (portfolio == null) throw new Exception();
            var portfolioDTO = _mapper.Map<GetPortfolioDTO>(portfolio);
            portfolioDTO.CategoryName = portfolio.Category.Name;
            return portfolioDTO;
        }

        public async Task SoftDelete(int id)
        {
            var portfolio = await _portfolioRepository.GetByIdAsync(p => p.Id == id);
            if (portfolio == null) throw new NullReferenceException("Axtarilan Id'li portfolio yoxdur!");

            portfolio.IsDeleted = !portfolio.IsDeleted;
            portfolio.UpdatedDate = DateTime.UtcNow.AddHours(4);
            await _portfolioRepository.CommitAsync();

        }


    }
}
