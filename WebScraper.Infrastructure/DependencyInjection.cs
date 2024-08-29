using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebScraper.Application.Interfaces;
using WebScraper.Infrastructure.Persistene;
using WebScraper.Infrastructure.Repositories;
using WebScraper.Infrastructure.WebSearchProviders.Bing;
using WebScraper.Infrastructure.WebSearchProviders.Google;

namespace WebScraper.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<WebScraperDbContext>(options =>
                options.UseSqlite("Data Source = WebScraper.db"));

            services.AddScoped<IWebSearchRepository, WebSearchRepository>();
            services.AddScoped<IWebSearchResultRepository, WebSearchResultRepository>();
            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<WebScraperDbContext>());

            // Search providers
            services.AddScoped<IGoogleSearchProvider, GoogleSearchProvider>();
            services.AddScoped<IBingSearchProvider, BingSearchProvider>();

            // HttpClients
            services.AddGoogleSearchHttpClient();
            services.AddBingSearchHttpClient();

            return services;
        }
    }
}
