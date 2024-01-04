using AutoMapper;
using BizLand.Business.DTOs.ProfessionDTOs;
using BizLand.Business.Services.Interfaces;
using BizLand.Core.Entity;
using BizLand.Core.Repositories.Interfaces;
using BizLand.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.Services.Implementations
{
    public class ProfessionService : IProfessionService
    {
        private readonly BizLandDbContext _context;
        private readonly IProfessionRepository _professionRepository;
        private readonly IMapper _mapper;
        public ProfessionService(BizLandDbContext context, IProfessionRepository professionRepository, IMapper mapper)
        {
            _context = context;
            _professionRepository = professionRepository;
            _mapper = mapper;
        }

        public DbSet<Profession> Table => throw new NotImplementedException();

        public async Task CreateAsync(CreateProfessionDTO professionDTO)
        {
            var profession =_mapper.Map<Profession>(professionDTO); 
            profession.CreatedDate = DateTime.UtcNow.AddHours(4);
            profession.UpdatedDate = DateTime.UtcNow.AddHours(4);
            profession.IsDeleted= false;
            await _professionRepository.CreateAsync(profession);
            await _professionRepository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var profession =await _professionRepository.GetByIdAsync(x => x.Id == id);
            if (profession == null) throw new Exception();
            _professionRepository.Delete(profession);
            await _professionRepository.CommitAsync();
            
        }

        public async Task SoftDelete(int id) 
        {
            var profession = await _professionRepository.GetByIdAsync(x => x.Id == id);
            if (profession == null) throw new Exception();
            profession.IsDeleted=!profession.IsDeleted;
            profession.UpdatedDate = DateTime.UtcNow.AddHours(5);
            await _professionRepository.CommitAsync();
        }
        public async Task<List<GetProfessionDTO>> GetAllAsync()
        {
            List<Profession> professions = await _professionRepository.GetAllAsync(x => x.IsDeleted == false);
            IEnumerable<GetProfessionDTO> professionDTOs = new List<GetProfessionDTO>();
            professionDTOs = professions.Select(x => new GetProfessionDTO { Name = x.Name});
            return professionDTOs.ToList();
        }

        public async Task<GetProfessionDTO> GetByIdAsync(int id)
        {
            var profession = await _professionRepository.GetByIdAsync(x => x.Id == id);
            if (profession == null) throw new Exception();
            GetProfessionDTO professionDTO = _mapper.Map<GetProfessionDTO>(profession);
            return professionDTO;
        }

        public async Task UpdateAsync(UpdateProfessionDTO professionDTO)
        {
            var profession = await _professionRepository.GetByIdAsync(x => x.Id == professionDTO.Id);
            if (profession == null) throw new Exception();
            profession = _mapper.Map(professionDTO, profession);
            profession.UpdatedDate = DateTime.UtcNow.AddHours(4);
            await _professionRepository.CommitAsync();
        }
    }
}
