namespace WebScraper.Domain.Models
{
    public class WebSearch
    {
        public required Guid Id { get; set; }
        public required string SearchExpression { get; set; }
        public required SearchProviders SearchProvider { get; set; }
        public required DateTime CreatedAt { get; set; }
        public ICollection<WebSearchResult> WebSearchResults { get; set; } = [];
    }
}
