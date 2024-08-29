using Microsoft.Extensions.DependencyInjection;

namespace WebScraper.Infrastructure.WebSearchProviders.Google
{
    public static class GoogleSearchExtensions
    {
        public static IServiceCollection AddGoogleSearchHttpClient(this IServiceCollection services)
        {
            services.AddHttpClient("Google", options =>
            {
                options.BaseAddress = new Uri("https://google.com");
            });

            return services;
        }
    }
}
