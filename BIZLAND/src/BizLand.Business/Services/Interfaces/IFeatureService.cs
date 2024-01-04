using BizLand.Business.DTOs.FeatureDTOs;
using BizLand.Core.Entity;
using Microsoft.EntityFrameworkCore;


namespace BizLand.Business.Services.Interfaces
{
    public interface IFeatureService
    {
        DbSet<Profession> Table { get; }
        Task CreateAsync(CreateFeatureDTO featureDTO);
        Task UpdateAsync(UpdateFeatureDTO featureDTO);
        Task DeleteAsync(int id);
        Task SoftDelete(int id);
        Task<GetFeatureDTO> GetByIdAsync(int id);
        Task<List<GetFeatureDTO>> GetAllAsync();
    }
}
