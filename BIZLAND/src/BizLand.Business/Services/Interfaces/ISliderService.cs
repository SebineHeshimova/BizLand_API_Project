using BizLand.Business.DTOs.FeatureDTOs;
using BizLand.Business.DTOs.SliderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.Services.Interfaces
{
    public interface ISliderService
    {
        Task CreateAsync(CreateSliderDTO sliderDTO);
        Task UpdateAsync(UpdateSliderDTO sliderDTO);
        Task DeleteAsync(int id);
        Task SoftDelete(int id);
        Task<GetSliderDTO> GetByIdAsync(int id);
        Task<List<GetSliderDTO>> GetAllAsync();
    }
}
