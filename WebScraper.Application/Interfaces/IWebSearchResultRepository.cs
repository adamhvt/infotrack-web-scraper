using WebScraper.Domain.Models;
using WebScraper.Infrastructure.Interfaces;

namespace WebScraper.Application.Interfaces
{
    public interface IWebSearchResultRepository : IRepository<WebSearchResult>
    {
        Task<IEnumerable<WebSearchResult>> GetAllAsync(Guid? webSearchId = null);
    }
}
