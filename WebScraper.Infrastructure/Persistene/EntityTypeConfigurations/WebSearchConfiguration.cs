using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebScraper.Domain.Models;

namespace WebScraper.Infrastructure.Persistene.EntityTypeConfigurations
{
    public class WebSearchConfiguration : IEntityTypeConfiguration<WebSearch>
    {
        public void Configure(EntityTypeBuilder<WebSearch> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.SearchProvider)
                .HasConversion(
                    x => x.ToString(),
                    x => (SearchProviders)Enum.Parse(typeof(SearchProviders), x));

            // Mock Data
            builder.HasData(new List<WebSearch>()
            {
                new WebSearch
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    SearchExpression = "land registry search",
                    SearchProvider = SearchProviders.Google,
                    CreatedAt = DateTime.Now.Subtract(new TimeSpan(8, 0, 0, 0)),
                },
                new WebSearch
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    SearchExpression = "InfoTrack",
                    SearchProvider = SearchProviders.Google,
                    CreatedAt = DateTime.Now.Subtract(new TimeSpan(8, 0, 0, 0)),
                }
            });
        }
    }
}
