using DemoOpenAI.DAL.Services;
using System.Net;
using System.Net.Http.Headers;

namespace DemoOpenAI.DependencyInjection
{
    public static class ServicesExtensions
    {
        public static void AddOpenAI(this IServiceCollection services, string apiKey)
        {
            services.AddScoped(s => new HttpClient
            {
                BaseAddress = new Uri("https://api.openai.com/v1/"),
                DefaultRequestHeaders =
                {
                    Authorization = new AuthenticationHeaderValue("Bearer", apiKey)
                }
            });
            services.AddScoped<IOpenAIService, OpenAIService>();
        }
    }
}
