namespace WebScraper.Domain.Models
{
    public class WebSearchResult
    {
        public required Guid Id { get; set; }
        public required Guid WebSearchId { get; set; }
        public required string Url { get; set; }
        public required string Rankings { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
