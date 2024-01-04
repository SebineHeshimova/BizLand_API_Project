using AutoMapper;
using BizLand.Business.DTOs.CategoryDTOs;
using BizLand.Business.DTOs.ProfessionDTOs;
using BizLand.Business.Services.Interfaces;
using BizLand.Core.Entity;
using BizLand.Core.Repositories.Interfaces;
using BizLand.Data.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.Services.Implementations
{
    public class CategoryService : ICategoryServise
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public DbSet<Profession> Table => throw new NotImplementedException();

        public async Task CreateAsync(CreateCategoryDTO categoryDTO)
        {
            var category =_mapper.Map<Category>(categoryDTO);
            category.CreatedDate= DateTime.UtcNow.AddHours(4);
            category.UpdatedDate= DateTime.UtcNow.AddHours(4);
            category.IsDeleted = false;
            await _categoryRepository.CreateAsync(category);
            await _categoryRepository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category=await _categoryRepository.GetByIdAsync(c=>c.Id==id);
            if (category == null) throw new Exception();
            _categoryRepository.Delete(category);
            await _categoryRepository.CommitAsync();
        }

        public async Task<List<GetCategoryDTO>> GetAllAsync()
        {
            List<Category> categories = await _categoryRepository.GetAllAsync(c => c.IsDeleted == false);
            IEnumerable<GetCategoryDTO> categoryDTOs = new List<GetCategoryDTO>();
            categoryDTOs = categories.Select(c => new GetCategoryDTO { Name=c.Name });
            return categoryDTOs.ToList();
        }

        public async Task<GetCategoryDTO> GetByIdAsync(int id)
        {
            var category=await _categoryRepository.GetByIdAsync(c=>c.Id == id);
            if (category == null) throw new Exception();
            var categoryDTO=_mapper.Map<GetCategoryDTO>(category);  
            return categoryDTO;
        }

        public async Task SoftDelete(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(c => c.Id == id);
            if (category == null) throw new Exception();
            category.IsDeleted= !category.IsDeleted;
            await _categoryRepository.CommitAsync();
        }

        public async Task UpdateAsync(UpdateCategoryDTO categoryDTO)
        {
            var category= await _categoryRepository.GetByIdAsync(c=>c.Id==categoryDTO.Id);
            if (category == null) throw new Exception();
            category = _mapper.Map(categoryDTO, category);
            category.UpdatedDate= DateTime.UtcNow.AddHours(4);
            await _categoryRepository.CommitAsync();
        }
    }
}
