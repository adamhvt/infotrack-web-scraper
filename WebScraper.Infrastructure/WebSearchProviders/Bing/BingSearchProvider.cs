using System.Web;
using WebScraper.Application.Interfaces;
using WebScraper.Domain.Models;

namespace WebScraper.Infrastructure.WebSearchProviders.Bing
{
    public class BingSearchProvider : IBingSearchProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BingSearchProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<WebScrapeResult> GetSearchReponseAsync(string searchExpression)
        {
            using var httpClient = _httpClientFactory.CreateClient("Bing");
            var queryString = $"search?count=100&q={HttpUtility.UrlEncode(searchExpression)}";
            var response = await httpClient.GetAsync(queryString);

            response.EnsureSuccessStatusCode();

            return new WebScrapeResult
            {
                Url = $"{httpClient.BaseAddress}{queryString}",
                RawHtml = await response.Content.ReadAsStringAsync()
            };
        }
    }
}
