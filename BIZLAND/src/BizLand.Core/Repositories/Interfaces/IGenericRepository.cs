using BizLand.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Core.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        DbSet<TEntity> Table { get; }
        Task CreateAsync(TEntity entity);
        Task CommitAsync();
        void Delete(TEntity entity);
        IQueryable<TEntity> GetQueryable();
        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>>? expression=null, params string[]? include);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, params string[]? include);
    }
}
