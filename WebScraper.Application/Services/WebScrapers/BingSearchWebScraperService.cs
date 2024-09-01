using HtmlAgilityPack;
using WebScraper.Application.Interfaces;
using WebScraper.Domain.Models;
using WebScraper.Infrastructure.Interfaces;

namespace WebScraper.Application.Services.WebScrapers
{
    public class BingSearchWebScraperService : IBingSearchWebScraperService
    {
        private readonly IBingSearchProvider _searchProvider;
        public BingSearchWebScraperService(IBingSearchProvider searchProvider)
        {
            _searchProvider = searchProvider;
        }

        public async Task<WebSearchResult> ProcessSearchRequestAsync(WebSearch webSearch)
        {
            var searchResponse = await _searchProvider.GetSearchReponseAsync(webSearch.SearchExpression);
            var rankings = GetSearchRankings(webSearch, searchResponse.RawHtml);

            return new WebSearchResult
            {
                Id = Guid.NewGuid(),
                WebSearchId = webSearch.Id,
                CreatedAt = DateTime.Now,
                Url = searchResponse.Url,
                Rankings = string.Join(", ", rankings)
            };
        }

        private List<int> GetSearchRankings(WebSearch webSearch, string rawHtml)
        {
            var rankings = new List<int>();
            List<string> searchResults = ExtractSearchResultsFromHtml(rawHtml);

            if (searchResults != null && searchResults.Any())
            {
                for (int i = 0; i < searchResults.Count && i < 100; i++)
                {
                    if (searchResults[i].Contains(webSearch.SearchExpression, StringComparison.InvariantCultureIgnoreCase))
                    {
                        rankings.Add(i + 1);
                    }
                }
            }

            if (rankings.Count == 0)
            {
                rankings.Add(0);
            }

            return rankings;
        }

        private static List<string> ExtractSearchResultsFromHtml(string rawHtml)
        {
            // TEMP - Replace original response with the mock one because search results are hidden by the cookie consent dialog
            rawHtml = MockSearchHtmlResponses.MockBingRespone;

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(rawHtml);
            var results = new List<string>();

            var mainNode = doc.DocumentNode
                .Descendants(0)
                .FirstOrDefault(node => node.Name == "main");

            if (mainNode == null)
            {
                throw new Exception("Error when processing Bing search response");
            }

            var searchResultNodes = mainNode
                .Descendants()
                .Where(node => node.Name == "li")
                .Select(node => node.InnerHtml)
                .ToList();

            return searchResultNodes;
        }
    }
}
