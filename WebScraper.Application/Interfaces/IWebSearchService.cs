using WebScraper.Domain.Models;

namespace WebScraper.Application.Interfaces
{
    public interface IWebSearchService
    {
        Task<WebSearchResult> CreateSearchAsync(string searchExpression, SearchProviders searchProvider, bool isAdHoc = false);
        Task<IEnumerable<WebSearch>> GetAllAsync();
        Task<WebSearch?> GetByIdAsync(Guid id);
        Task<WebSearchResult?> RepeatSearchAsync(Guid searchId);
    }
}
