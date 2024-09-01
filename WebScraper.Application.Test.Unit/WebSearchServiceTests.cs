using FluentAssertions;
using NSubstitute;
using System.Web;
using WebScraper.Application.Interfaces;
using WebScraper.Application.Services;
using WebScraper.Domain.Models;
using WebScraper.Infrastructure.Interfaces;

namespace WebScraper.Application.Test.Unit
{
    public class WebSearchServiceTests
    {
        private readonly IGoogleSearchWebScraperService _googleSearchWebScraperService;
        private readonly IBingSearchWebScraperService _bingSearchWebScraperService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebSearchRepository _webSearchRepository;
        private readonly IWebSearchResultRepository _webSearchResultRepository;
        private readonly WebSearchService _webSearchService;

        public WebSearchServiceTests()
        {
            _googleSearchWebScraperService = Substitute.For<IGoogleSearchWebScraperService>();
            _bingSearchWebScraperService = Substitute.For<IBingSearchWebScraperService>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _webSearchRepository = Substitute.For<IWebSearchRepository>();
            _webSearchResultRepository = Substitute.For<IWebSearchResultRepository>();

            _webSearchService = new WebSearchService(
                _googleSearchWebScraperService,
                _bingSearchWebScraperService,
                _unitOfWork,
                _webSearchRepository,
                _webSearchResultRepository);
        }

        [Fact]
        public async Task CreateSearchAsync_ShouldReturnWebSearchResult_WhenIsAdHocIsTrue()
        {
            // Arrange
            var searchExpression = "test";
            var searchProvider = SearchProviders.Google;
            var webSearchResult = new WebSearchResult
            {
                Id = Guid.NewGuid(),
                WebSearchId = Guid.NewGuid(),
                Url = $"https://google.com/search?num=100&q={HttpUtility.UrlEncode(searchExpression)}",
                Rankings = "1, 2, 10",
                CreatedAt = DateTime.Now
            };

            _googleSearchWebScraperService.ProcessSearchRequestAsync(Arg.Any<WebSearch>())
                .Returns(Task.FromResult(webSearchResult));

            // Act
            var result = await _webSearchService.CreateSearchAsync(searchExpression, searchProvider, true);

            // Assert
            result.Should().BeEquivalentTo(webSearchResult);
        }

        [Fact]
        public async Task CreateSearchAsync_ShouldSaveWebSearchAndWebSearchResult_WhenIsAdHocIsFalse()
        {
            // Arrange
            var searchExpression = "test";
            var searchProvider = SearchProviders.Google;
            var webSearchResult = new WebSearchResult
            {
                Id = Guid.NewGuid(),
                WebSearchId = Guid.NewGuid(),
                Url = $"https://google.com/search?num=100&q={HttpUtility.UrlEncode(searchExpression)}",
                Rankings = "1, 2, 10",
                CreatedAt = DateTime.Now
            };

            _googleSearchWebScraperService.ProcessSearchRequestAsync(Arg.Any<WebSearch>())
                .Returns(Task.FromResult(webSearchResult));

            _webSearchResultRepository.GetByIdAsync(Arg.Any<Guid>())
                .Returns(Task.FromResult<WebSearchResult?>(webSearchResult));

            // Act
            var result = await _webSearchService.CreateSearchAsync(searchExpression, searchProvider, false);

            // Assert
            await _webSearchRepository.Received(1).AddAsync(Arg.Any<WebSearch>());
            await _webSearchResultRepository.Received(1).AddAsync(webSearchResult);
            await _unitOfWork.Received(1).CommitChangesAsync();
            result.Should().BeEquivalentTo(webSearchResult);
        }

        [Fact]
        public async Task CreateSearchAsync_ShouldThrowException_WhenWebSearchResultIsNull()
        {
            // Arrange
            var searchExpression = "test";
            var searchProvider = SearchProviders.Google;
            var webSearchResult = new WebSearchResult
            {
                Id = Guid.NewGuid(),
                WebSearchId = Guid.NewGuid(),
                Url = $"https://google.com/search?num=100&q={HttpUtility.UrlEncode(searchExpression)}",
                Rankings = "1",
                CreatedAt = DateTime.Now
            };

            _googleSearchWebScraperService.ProcessSearchRequestAsync(Arg.Any<WebSearch>())
                .Returns(Task.FromResult(webSearchResult));

            _webSearchResultRepository.GetByIdAsync(Arg.Any<Guid>())
                .Returns(Task.FromResult<WebSearchResult?>(null));

            // Act
            Func<Task> act = async () => await _webSearchService.CreateSearchAsync(searchExpression, searchProvider, false);

            // Assert
            await act.Should().ThrowAsync<Exception>().WithMessage("Unexpected error when returning search results");
        }

        [Fact]
        public async Task RepeatSearchAsync_ShouldReturnNull_WhenWebSearchNotFound()
        {
            // Arrange
            var searchId = Guid.NewGuid();
            _webSearchRepository.GetByIdAsync(searchId).Returns(Task.FromResult<WebSearch?>(null));

            // Act
            var result = await _webSearchService.RepeatSearchAsync(searchId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task RepeatSearchAsync_ShouldReturnWebSearchResult_WhenWebSearchIsFound()
        {
            // Arrange
            var searchId = Guid.NewGuid();
            var webSearch = new WebSearch
            {
                Id = searchId,
                SearchExpression = "test",
                SearchProvider = SearchProviders.Google,
                CreatedAt = DateTime.Now
            };
            var webSearchResult = new WebSearchResult
            {
                Id = Guid.NewGuid(),
                WebSearchId = searchId,
                Url = $"https://google.com/search?num=100&q={HttpUtility.UrlEncode(webSearch.SearchExpression)}",
                Rankings = "1",
                CreatedAt = DateTime.Now
            };

            _webSearchRepository.GetByIdAsync(searchId).Returns(Task.FromResult<WebSearch?>(webSearch));
            _googleSearchWebScraperService.ProcessSearchRequestAsync(webSearch).Returns(Task.FromResult(webSearchResult));

            // Act
            var result = await _webSearchService.RepeatSearchAsync(searchId);

            // Assert
            result.Should().BeEquivalentTo(webSearchResult);
            await _webSearchResultRepository.Received(1).AddAsync(webSearchResult);
            await _unitOfWork.Received(1).CommitChangesAsync();
        }
    }
}