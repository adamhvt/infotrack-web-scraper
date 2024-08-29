using WebScraper.Domain.Models;

namespace WebScraper.Application.Interfaces
{
    public interface IWebSearchResultService
    {
        Task<IEnumerable<WebSearchResult>> GetAllAsync(Guid? webSearchId = null);
        Task<WebSearchResult?> GetByIdAsync(Guid id);
    }
}
