using Microsoft.Extensions.DependencyInjection;
using WebScraper.Application.Interfaces;
using WebScraper.Application.Services;
using WebScraper.Application.Services.WebScrapers;
using WebScraper.Infrastructure.Interfaces;

namespace WebScraper.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IWebSearchService, WebSearchService>();
            services.AddScoped<IWebSearchResultService, WebSearchResultService>();
            services.AddScoped<IGoogleSearchWebScraperService, GoogleSearchWebScraperService>();
            services.AddScoped<IBingSearchWebScraperService, BingSearchWebScraperService>();

            return services;
        }
    }
}
