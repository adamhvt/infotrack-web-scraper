using Microsoft.EntityFrameworkCore;
using WebScraper.Infrastructure.Interfaces;

namespace WebScraper.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _set;

        public RepositoryBase(DbContext context)
        {
            _context = context;
            _set = context.Set<TEntity>();
        }

        public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _set.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _set.ToListAsync();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _set.AddAsync(entity);
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _set.AsQueryable();
        }
    }
}
