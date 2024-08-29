using Microsoft.Extensions.DependencyInjection;

namespace WebScraper.Infrastructure.WebSearchProviders.Bing
{
    public static class BingSearchExtensions
    {
        public static IServiceCollection AddBingSearchHttpClient(this IServiceCollection services)
        {
            services.AddHttpClient("Bing", options =>
            {
                options.BaseAddress = new Uri("https://bing.com");
            });

            return services;
        }
    }
}
