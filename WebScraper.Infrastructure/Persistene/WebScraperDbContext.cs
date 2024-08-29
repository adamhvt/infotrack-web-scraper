using Microsoft.EntityFrameworkCore;
using WebScraper.Application.Interfaces;
using WebScraper.Domain.Models;
using WebScraper.Infrastructure.Persistene.EntityTypeConfigurations;

namespace WebScraper.Infrastructure.Persistene
{
    public class WebScraperDbContext : DbContext, IUnitOfWork
    {
        public DbSet<WebSearch> WebSearches { get; set; }
        public DbSet<WebSearchResult> WebSearchResults { get; set; }

        public WebScraperDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WebSearchConfiguration());
            modelBuilder.ApplyConfiguration(new WebSearchResultConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public async Task CommitChangesAsync()
        {
            await base.SaveChangesAsync();
        }
    }
}
