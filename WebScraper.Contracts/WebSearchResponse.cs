using System.Text.Json.Serialization;
using WebScraper.Domain.Models;

namespace WebScraper.Contracts
{
    public record WebSearchResponse
    {
        public required Guid Id { get; set; }
        public required string SearchExpression { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public required SearchProviders SearchProvider { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required List<WebSearchResultResponse> WebSearchResults { get; set; } = [];
    }
}
