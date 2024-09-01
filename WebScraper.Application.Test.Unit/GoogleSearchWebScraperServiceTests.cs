using FluentAssertions;
using NSubstitute;
using System.Web;
using WebScraper.Application.Interfaces;
using WebScraper.Application.Services.WebScrapers;
using WebScraper.Domain.Models;

namespace WebScraper.Tests.Services
{
    public class GoogleSearchWebScraperServiceTests
    {
        private readonly IGoogleSearchProvider _searchProvider;
        private readonly GoogleSearchWebScraperService _sut;

        public GoogleSearchWebScraperServiceTests()
        {
            _searchProvider = Substitute.For<IGoogleSearchProvider>();
            _sut = new GoogleSearchWebScraperService(_searchProvider);
        }

        [Fact]
        public async Task ProcessSearchRequestAsync_ShouldReturnWebSearchResult()
        {
            // Arrange
            var webSearch = new WebSearch
            {
                Id = Guid.NewGuid(),
                SearchExpression = "test",
                SearchProvider = SearchProviders.Google,
                CreatedAt = DateTime.Now
            };

            var webScrapeResult = new WebScrapeResult
            {
                RawHtml = MockSearchHtmlResponses.MockGoogleResponse,
                Url = $"https://google.com/search?num=100&q={HttpUtility.UrlEncode(webSearch.SearchExpression)}"

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
                SearchProvider = SearchProviders.Google,
                CreatedAt = DateTime.Now
            };

            var webScrapeResult = new WebScrapeResult
            {
                RawHtml = MockSearchHtmlResponses.MockGoogleResponse,
                Url = $"https://google.com/search?num=100&q={HttpUtility.UrlEncode(webSearch.SearchExpression)}"
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