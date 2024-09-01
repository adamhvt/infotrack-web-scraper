using System.Web;
using WebScraper.Application.Interfaces;
using WebScraper.Domain.Models;

namespace WebScraper.Infrastructure.WebSearchProviders.Google
{
    public class GoogleSearchProvider : IGoogleSearchProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GoogleSearchProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<WebScrapeResult> GetSearchReponseAsync(string searchExpression)
        {
            using var httpClient = _httpClientFactory.CreateClient("Google");
            var queryString = $"search?num=100&q={HttpUtility.UrlEncode(searchExpression)}";
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
