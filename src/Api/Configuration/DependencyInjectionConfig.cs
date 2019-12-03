using Dal.Repositories;
using Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegistrationContainer(this IServiceCollection services)
        {
            services.AddSingleton<IUrlRepository, UrlRepository>();
            services.AddScoped<IUrlService, UrlService>();
        }
    }
}