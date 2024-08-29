using WebScraper.Domain.Models;

namespace WebScraper.Application.Interfaces
{
    public interface ISearchProvider
    {
        public Task<WebScrapeResult> GetSearchReponseAsync(string searchExpression);
    }
}
