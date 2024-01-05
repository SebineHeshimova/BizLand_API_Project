using AutoMapper;
using BizLand.Business.DTOs.FeatureDTOs;
using BizLand.Business.DTOs.SliderDTOs;
using BizLand.Business.Services.Interfaces;
using BizLand.Core.Entity;
using BizLand.Core.Repositories.Interfaces;
using BizLand.Data.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.Services.Implementations
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IMapper _mapper;
        public SliderService(ISliderRepository sliderRepository, IMapper mapper)
        {
            _sliderRepository = sliderRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateSliderDTO sliderDTO)
        {
            var slider = _mapper.Map<Slider>(sliderDTO);
            slider.CreatedDate = DateTime.UtcNow.AddHours(4);
            slider.UpdatedDate = DateTime.UtcNow.AddHours(4);
            slider.IsDeleted = false;
            await _sliderRepository.CreateAsync(slider);
            await _sliderRepository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var slider = await _sliderRepository.GetByIdAsync(f => f.Id == id);
            if (slider == null) throw new Exception();
            _sliderRepository.Delete(slider);
            await _sliderRepository.CommitAsync();
        }

        public async Task<List<GetSliderDTO>> GetAllAsync()
        {
            var slider = await _sliderRepository.GetAllAsync(f => f.IsDeleted == false);
            IEnumerable<GetSliderDTO> sliderDTOs = new List<GetSliderDTO>();
            sliderDTOs = slider.Select(s => new GetSliderDTO { Title1 = s.Title1, Title2 = s.Title2, Description = s.Description, Button1Text = s.Button1Text, Button2Text = s.Button2Text, Button1Url = s.Button1Url, Button2Url = s.Button2Url });
            return sliderDTOs.ToList();
        }

        public async Task<GetSliderDTO> GetByIdAsync(int id)
        {
            var slider = await _sliderRepository.GetByIdAsync(f => f.Id == id);
            if (slider == null) throw new Exception();
            var sliderDTO = _mapper.Map<GetSliderDTO>(slider);
            return sliderDTO;
        }

        public async Task SoftDelete(int id)
        {
            var slider = await _sliderRepository.GetByIdAsync(f => f.Id == id);
            if (slider == null) throw new Exception();
            slider.IsDeleted = !slider.IsDeleted;
            slider.UpdatedDate = DateTime.UtcNow.AddHours(4);
            _sliderRepository.CommitAsync();
        }

        public async Task UpdateAsync(UpdateSliderDTO sliderDTO)
        {
            var slider = await _sliderRepository.GetByIdAsync(s => s.Id == sliderDTO.Id);
            if (slider == null) throw new Exception();
            slider = _mapper.Map(sliderDTO, slider);
            slider.UpdatedDate = DateTime.UtcNow.AddHours(4);
            _sliderRepository.CommitAsync();
        }
    }
}
