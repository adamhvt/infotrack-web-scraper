namespace WebScraper.Infrastructure.Interfaces
{
    public interface IRepository<TEntity>  where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        IQueryable<TEntity> AsQueryable();
    }
}
