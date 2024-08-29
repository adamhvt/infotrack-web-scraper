using WebScraper.Contracts;
using WebScraper.Domain.Models;

namespace WebScraper.Api.Mappings
{
    public static class WebSearchMapping
    {
        public static WebSearchResponse MapToResponse(this WebSearch webSearch)
        {
            return new WebSearchResponse
            {
                Id = webSearch.Id,
                CreatedAt = webSearch.CreatedAt,
                SearchExpression = webSearch.SearchExpression,
                SearchProvider = webSearch.SearchProvider,
                WebSearchResults = webSearch.WebSearchResults.Select(x => x.MapToResponse()).ToList(),
            };
        }
    }
}
