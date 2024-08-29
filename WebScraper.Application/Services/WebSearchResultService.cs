using WebScraper.Application.Interfaces;
using WebScraper.Domain.Models;

namespace WebScraper.Application.Services
{
    public class WebSearchResultService : IWebSearchResultService
    {
        private readonly IWebSearchResultRepository _webSearchResultRepository;

        public WebSearchResultService(IWebSearchResultRepository webSearchResultRepository)
        {
            _webSearchResultRepository = webSearchResultRepository;
        }

        public async Task<IEnumerable<WebSearchResult>> GetAllAsync(Guid? webSearchId = null)
        {
            return await _webSearchResultRepository.GetAllAsync(webSearchId);
        }

        public async Task<WebSearchResult?> GetByIdAsync(Guid id)
        {
            return await _webSearchResultRepository.GetByIdAsync(id);
        }
    }
}
