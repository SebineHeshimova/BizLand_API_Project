using BizLand.Core.Entity;
using BizLand.Core.Repositories.Interfaces;
using BizLand.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Data.Repositories.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly BizLandDbContext _context;

        public GenericRepository(BizLandDbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, params string[]? include)
        {
            var query = GetQuery(include);
            if (expression != null)
            {
                query = query.Where(expression);
            }
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>>? expression = null, params string[]? include)
        {
            var query=GetQuery(include);
            return expression!=null ? await query.Where(expression).FirstOrDefaultAsync() : await query.FirstOrDefaultAsync();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        private IQueryable<TEntity> GetQuery(string[]? includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }
    }
}
