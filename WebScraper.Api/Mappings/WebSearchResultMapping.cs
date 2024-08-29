using WebScraper.Contracts;
using WebScraper.Domain.Models;

namespace WebScraper.Api.Mappings
{
    public static class WebSearchResultMapping
    {
        public static WebSearchResultResponse MapToResponse(this WebSearchResult webSearchResult)
        {
            return new WebSearchResultResponse
            {
                Id = webSearchResult.Id,
                WebSearchId = webSearchResult.WebSearchId,
                CreatedAt = webSearchResult.CreatedAt,
                Rankings = webSearchResult.Rankings,
                Url = webSearchResult.Url,
            };
        }
    }
}
