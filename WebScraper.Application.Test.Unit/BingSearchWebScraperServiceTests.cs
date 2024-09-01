using FluentAssertions;
using NSubstitute;
using System.Web;
using WebScraper.Application.Interfaces;
using WebScraper.Application.Services.WebScrapers;
using WebScraper.Domain.Models;

namespace WebScraper.Tests.Services
{
    public class BingSearchWebScraperServiceTests
    {
        private readonly IBingSearchProvider _searchProvider;
        private readonly BingSearchWebScraperService _sut;

        public BingSearchWebScraperServiceTests()
        {
            _searchProvider = Substitute.For<IBingSearchProvider>();
            _sut = new BingSearchWebScraperService(_searchProvider);
        }

        [Fact]
        public async Task ProcessSearchRequestAsync_ShouldReturnWebSearchResult()
        {
            // Arrange
            var webSearch = new WebSearch
            {
                Id = Guid.NewGuid(),
                SearchExpression = "test",
                SearchProvider = SearchProviders.Bing,
                CreatedAt = DateTime.Now
            };

            var webScrapeResult = new WebScrapeResult
            {
                RawHtml = MockSearchHtmlResponses.MockBingRespone,
                Url = $"http://bing.com/search?count=100&q={HttpUtility.UrlEncode(webSearch.SearchExpression)}"
            };

            _searchProvider.GetSearchReponseAsync(webSearch.SearchExpression)
                .Returns(Task.FromResult(webScrapeResult));

            // Act
            var result = await _sut.ProcessSearchRequestAsync(webSearch);

            // Assert
            result.Should().NotBeNull();
            result.WebSearchId.Should().Be(webSearch.Id);
            result.Url.Should().NotBeNullOrEmpty();
            result.Rankings.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task ProcessSearchRequestAsync_ShouldHandleEmptySearchResults()
        {
            // Arrange
            var webSearch = new WebSearch
            {
                Id = Guid.NewGuid(),
                SearchExpression = "_____test_____",
                SearchProvider = SearchProviders.Bing,
                CreatedAt = DateTime.Now
            };

            var webScrapeResult = new WebScrapeResult
            {
                RawHtml = MockSearchHtmlResponses.MockBingRespone,
                Url = $"http://bing.com/search?count=100&q={HttpUtility.UrlEncode(webSearch.SearchExpression)}"
            };

            _searchProvider.GetSearchReponseAsync(webSearch.SearchExpression)
                .Returns(Task.FromResult(webScrapeResult));

            // Act
            var result = await _sut.ProcessSearchRequestAsync(webSearch);

            // Assert
            result.Should().NotBeNull();
            result.WebSearchId.Should().Be(webSearch.Id);
            result.Url.Should().NotBeNullOrEmpty();
            result.Rankings.Should().BeEquivalentTo("0");
        }
    }
}