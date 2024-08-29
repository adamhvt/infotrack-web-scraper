using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebScraper.Domain.Models;

namespace WebScraper.Contracts
{
    public record WebSearchRequest
    {
        [MinLength(3)]
        public required string SearchExpression { get; init; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public required SearchProviders SearchProvider { get; init; }
        public bool IsAdHoc { get; init; } = false;
    }
}
