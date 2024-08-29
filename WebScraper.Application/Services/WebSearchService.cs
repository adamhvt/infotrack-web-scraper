using WebScraper.Application.Interfaces;
using WebScraper.Domain.Models;
using WebScraper.Infrastructure.Interfaces;

namespace WebScraper.Application.Services
{
    public class WebSearchService : IWebSearchService
    {
        private readonly IGoogleSearchWebScraperService _googleSearchWebScraperService;
        private readonly IBingSearchWebScraperService _bingSearchWebScraperService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebSearchRepository _webSearchRepository;
        private readonly IWebSearchResultRepository _webSearchResultRepository;

        public WebSearchService(
            IGoogleSearchWebScraperService googleSearchWebScraperService,
            IBingSearchWebScraperService bingSearchWebScraperService,
            IUnitOfWork unitOfWork,
            IWebSearchRepository webSearchRepository,
            IWebSearchResultRepository webSearchResultRepository)
        {
            _googleSearchWebScraperService = googleSearchWebScraperService;
            _bingSearchWebScraperService = bingSearchWebScraperService;
            _unitOfWork = unitOfWork;
            _webSearchRepository = webSearchRepository;
            _webSearchResultRepository = webSearchResultRepository;
        }

        public async Task<WebSearchResult> CreateSearchAsync(string searchExpression, SearchProviders searchProvider, bool isAdHoc = false)
        {
            var webSearch = new WebSearch
            {
                Id = Guid.NewGuid(),
                SearchExpression = searchExpression,
                SearchProvider = searchProvider,
                CreatedAt = DateTime.Now
            };

            var webSearchResult = await ProcessSearchRequestAsync(webSearch);

            if (isAdHoc)
            {
                return webSearchResult;
            }

            await _webSearchRepository.AddAsync(webSearch);
            await _webSearchResultRepository.AddAsync(webSearchResult);
            await _unitOfWork.CommitChangesAsync();

            var result = await _webSearchResultRepository.GetByIdAsync(webSearchResult.Id);
            if (result == null)
            {
                throw new Exception("Unexpected error when returning search results");
            }

            return result;
        }

        public async Task<WebSearchResult?> RepeatSearchAsync(Guid searchId)
        {
            var webSearch = await _webSearchRepository.GetByIdAsync(searchId);
            if (webSearch == null)
            {
                return null;
            }

            var searchResult = await ProcessSearchRequestAsync(webSearch);
            await _webSearchResultRepository.AddAsync(searchResult);
            await _unitOfWork.CommitChangesAsync();

            return searchResult;
        }

        public async Task<IEnumerable<WebSearch>> GetAllAsync()
        {
            return await _webSearchRepository.GetAllAsync();
        }

        public async Task<WebSearch?> GetByIdAsync(Guid id)
        {
            return await _webSearchRepository.GetByIdAsync(id);
        }

        private Task<WebSearchResult> ProcessSearchRequestAsync(WebSearch webSearch)
        {
            var resolvedWebScraper = ResolveWebScraper(webSearch.SearchProvider);
            return resolvedWebScraper.ProcessSearchRequestAsync(webSearch);
        }

        private IWebScraperService ResolveWebScraper(SearchProviders searchProvider = SearchProviders.Google)
        {
            switch (searchProvider)
            {
                case SearchProviders.Google:
                    return _googleSearchWebScraperService;
                case SearchProviders.Bing:
                    return _bingSearchWebScraperService;
                default:
                    throw new ArgumentException("Unsupported search provider was set when a search was initiated");
            }
        }
    }
}
