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
    public interface IProfessionService
    {
        DbSet<Profession> Table { get; }
        Task CreateAsync(CreateProfessionDTO professionDTO);
        Task UpdateAsync(UpdateProfessionDTO professionDTO);
        Task DeleteAsync(int id);
        Task SoftDelete(int id);
        Task<GetProfessionDTO> GetByIdAsync(int id);
        Task<List<GetProfessionDTO>> GetAllAsync();
    }
}
