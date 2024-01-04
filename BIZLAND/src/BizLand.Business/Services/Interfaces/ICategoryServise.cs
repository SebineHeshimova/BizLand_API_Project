using BizLand.Business.DTOs.CategoryDTOs;
using BizLand.Business.DTOs.ProfessionDTOs;
using BizLand.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.Services.Interfaces
{
    public interface ICategoryServise
    {
        DbSet<Profession> Table { get; }
        Task CreateAsync(CreateCategoryDTO categoryDTO);
        Task UpdateAsync(UpdateCategoryDTO categoryDTO);
        Task DeleteAsync(int id);
        Task SoftDelete(int id);
        Task<GetCategoryDTO> GetByIdAsync(int id);
        Task<List<GetCategoryDTO>> GetAllAsync();
    }
}
