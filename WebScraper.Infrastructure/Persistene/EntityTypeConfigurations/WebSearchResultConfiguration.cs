using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebScraper.Domain.Models;

namespace WebScraper.Infrastructure.Persistene.EntityTypeConfigurations
{
    public class WebSearchResultConfiguration : IEntityTypeConfiguration<WebSearchResult>
    {
        public void Configure(EntityTypeBuilder<WebSearchResult> builder)
        {
            builder.HasKey(x => x.Id);

            // Mock Data
            builder.HasData(new List<WebSearchResult>()
            {
                // Mock results for "00000000-0000-0000-0000-000000000001"
                new WebSearchResult
                {
                    Id = Guid.NewGuid(),
                    WebSearchId = new Guid("00000000-0000-0000-0000-000000000001"),
                    CreatedAt = DateTime.Now,
                    Rankings = "1, 8, 16, 32",
                    Url = "https://www.google.co.uk/search?num=100&q=land+registry+search"
                },
                new WebSearchResult
                {
                    Id = Guid.NewGuid(),
                    WebSearchId = new Guid("00000000-0000-0000-0000-000000000001"),
                    CreatedAt = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)),
                    Rankings = "1, 4, 16, 47, 68",
                    Url = "https://www.google.co.uk/search?num=100&q=land+registry+search"
                },
                new WebSearchResult
                {
                    Id = Guid.NewGuid(),
                    WebSearchId = new Guid("00000000-0000-0000-0000-000000000001"),
                    CreatedAt = DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0)),
                    Rankings = "3, 10, 16, 47",
                    Url = "https://www.google.co.uk/search?num=100&q=land+registry+search"
                },
                new WebSearchResult
                {
                    Id = Guid.NewGuid(),
                    WebSearchId = new Guid("00000000-0000-0000-0000-000000000001"),
                    CreatedAt = DateTime.Now.Subtract(new TimeSpan(3, 0, 0, 0)),
                    Rankings = "2, 7, 20, 60, 89",
                    Url = "https://www.google.co.uk/search?num=100&q=land+registry+search"
                },
                new WebSearchResult
                {
                    Id = Guid.NewGuid(),
                    WebSearchId = new Guid("00000000-0000-0000-0000-000000000001"),
                    CreatedAt = DateTime.Now.Subtract(new TimeSpan(4, 0, 0, 0)),
                    Rankings = "4, 8, 16, 32",
                    Url = "https://www.google.co.uk/search?num=100&q=land+registry+search"
                },
                new WebSearchResult
                {
                    Id = Guid.NewGuid(),
                    WebSearchId = new Guid("00000000-0000-0000-0000-000000000001"),
                    CreatedAt = DateTime.Now.Subtract(new TimeSpan(5, 0, 0, 0)),
                    Rankings = "1, 8, 20, 32",
                    Url = "https://www.google.co.uk/search?num=100&q=land+registry+search"
                },

                // Mock results for "00000000-0000-0000-0000-000000000002"
                new WebSearchResult
                {
                    Id = Guid.NewGuid(),
                    WebSearchId = new Guid("00000000-0000-0000-0000-000000000002"),
                    CreatedAt = DateTime.Now,
                    Rankings = "20, 24, 42, 80, 87, 99",
                    Url = "https://www.google.co.uk/search?num=100&q=infotrack"
                },
                new WebSearchResult
                {
                    Id = Guid.NewGuid(),
                    WebSearchId = new Guid("00000000-0000-0000-0000-000000000002"),
                    CreatedAt = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)),
                    Rankings = "23, 34, 67",
                    Url = "https://www.google.co.uk/search?num=100&q=infotrack"
                },
                new WebSearchResult
                {
                    Id = Guid.NewGuid(),
                    WebSearchId = new Guid("00000000-0000-0000-0000-000000000002"),
                    CreatedAt = DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0)),
                    Rankings = "16, 26, 42, 60",
                    Url = "https://www.google.co.uk/search?num=100&q=infotrack"
                },
                new WebSearchResult
                {
                    Id = Guid.NewGuid(),
                    WebSearchId = new Guid("00000000-0000-0000-0000-000000000002"),
                    CreatedAt = DateTime.Now.Subtract(new TimeSpan(3, 0, 0, 0)),
                    Rankings = "10, 18, 37, 67, 90, 98",
                    Url = "https://www.google.co.uk/search?num=100&q=infotrack"
                },
                new WebSearchResult
                {
                    Id = Guid.NewGuid(),
                    WebSearchId = new Guid("00000000-0000-0000-0000-000000000002"),
                    CreatedAt = DateTime.Now.Subtract(new TimeSpan(4, 0, 0, 0)),
                    Rankings = "12, 30, 40, 48, 52, 66, 80",
                    Url = "https://www.google.co.uk/search?num=100&q=infotrack"
                },
                new WebSearchResult
                {
                    Id = Guid.NewGuid(),
                    WebSearchId = new Guid("00000000-0000-0000-0000-000000000002"),
                    CreatedAt = DateTime.Now.Subtract(new TimeSpan(5, 0, 0, 0)),
                    Rankings = "1, 8, 18, 20, 40, 60, 82",
                    Url = "https://www.google.co.uk/search?num=100&q=infotrack"
                }
            });
        }
    }
}
