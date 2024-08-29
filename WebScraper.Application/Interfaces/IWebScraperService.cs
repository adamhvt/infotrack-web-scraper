using WebScraper.Domain.Models;

namespace WebScraper.Infrastructure.Interfaces
{
    public interface IWebScraperService
    {
        public Task<WebSearchResult> ProcessSearchRequestAsync(WebSearch webSearch);
    }
}
