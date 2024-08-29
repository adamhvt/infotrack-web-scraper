using Microsoft.EntityFrameworkCore;
using WebScraper.Application.Interfaces;
using WebScraper.Domain.Models;
using WebScraper.Infrastructure.Persistene;

namespace WebScraper.Infrastructure.Repositories
{
    public class WebSearchRepository : RepositoryBase<WebSearch>, IWebSearchRepository
    {
        private readonly WebScraperDbContext dbContext;

        public WebSearchRepository(WebScraperDbContext searchResultsDbContext)
            : base(searchResultsDbContext)
        {
            dbContext = searchResultsDbContext;
        }

        public override async Task<IEnumerable<WebSearch>> GetAllAsync()
        {
            return await dbContext.WebSearches.OrderByDescending(x => x.CreatedAt).ToListAsync();
        }

        public override async Task<WebSearch?> GetByIdAsync(Guid id)
        {
            return await dbContext.WebSearches
                .Include(x => x.WebSearchResults)
                .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
