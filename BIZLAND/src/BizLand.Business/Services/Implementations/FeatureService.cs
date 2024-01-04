using AutoMapper;
using BizLand.Business.DTOs.FeatureDTOs;
using BizLand.Business.DTOs.ProfessionDTOs;
using BizLand.Business.Services.Interfaces;
using BizLand.Core.Entity;
using BizLand.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.Services.Implementations
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IMapper _mapper;
        public FeatureService(IFeatureRepository featureRepository, IMapper mapper)
        {
            _featureRepository = featureRepository;
            _mapper = mapper;
        }

        public DbSet<Profession> Table => throw new NotImplementedException();

        public async Task CreateAsync(CreateFeatureDTO featureDTO)
        {
            var feature = _mapper.Map<Feature>(featureDTO);
            feature.CreatedDate = DateTime.UtcNow.AddHours(4);
            feature.UpdatedDate = DateTime.UtcNow.AddHours(4);
            feature.IsDeleted = false;
            await _featureRepository.CreateAsync(feature);
            await _featureRepository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var feature=await _featureRepository.GetByIdAsync(f=>f.Id == id);
            if (feature == null) throw new Exception();
            _featureRepository.Delete(feature);
            await _featureRepository.CommitAsync();
        }

        public async Task<List<GetFeatureDTO>> GetAllAsync()
        {
            var feature=await _featureRepository.GetAllAsync(f=>f.IsDeleted==false);
            IEnumerable<GetFeatureDTO> featureDTOs = new List<GetFeatureDTO>();
            featureDTOs = feature.Select(f => new GetFeatureDTO { Title = f.Title, Description= f.Description, Icon=f.Icon });
            return featureDTOs.ToList();
        }

        public async Task<GetFeatureDTO> GetByIdAsync(int id)
        {
            var feature=await _featureRepository.GetByIdAsync(f=>f.Id==id);
            if(feature == null) throw new Exception();
            var featureDTO = _mapper.Map<GetFeatureDTO>(feature);
            return featureDTO;
        }

        public async Task SoftDelete(int id)
        {
            var feature=await _featureRepository.GetByIdAsync(f=>f.Id == id);
            if (feature == null) throw new Exception();
            feature.IsDeleted=!feature.IsDeleted;
            feature.UpdatedDate= DateTime.UtcNow.AddHours(4);
            _featureRepository.CommitAsync();
        }

        public async Task UpdateAsync(UpdateFeatureDTO featureDTO)
        {
            var feature =await _featureRepository.GetByIdAsync(f=>f.Id==featureDTO.Id);
            if (feature == null) throw new Exception();
            feature = _mapper.Map(featureDTO, feature);
            feature.UpdatedDate= DateTime.UtcNow.AddHours(4);
            _featureRepository.CommitAsync();
        }
    }
}
