namespace WebScraper.Domain.Models
{
    public record WebScrapeResult
    {
        public string Url { get; set; }
        public string RawHtml { get; set; }
    }
}
