using Microsoft.EntityFrameworkCore;
using WebScraper.Application.Interfaces;
using WebScraper.Domain.Models;
using WebScraper.Infrastructure.Persistene;

namespace WebScraper.Infrastructure.Repositories
{
    public class WebSearchResultRepository : RepositoryBase<WebSearchResult>, IWebSearchResultRepository
    {
        private readonly WebScraperDbContext _searchResultsDbContext;

        public WebSearchResultRepository(WebScraperDbContext searchResultsDbContext)
            : base(searchResultsDbContext)
        {
            _searchResultsDbContext = searchResultsDbContext;
        }

        public async Task<IEnumerable<WebSearchResult>> GetAllAsync(Guid? webSearchId = null)
        {
            var query = _searchResultsDbContext.WebSearchResults.AsQueryable();

            if (webSearchId != null)
            {
                query = query.Where(x => x.WebSearchId == webSearchId);
            }

            return await query.OrderByDescending(x => x.CreatedAt).ToListAsync();
        }
    }
}
