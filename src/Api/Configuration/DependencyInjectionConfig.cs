using Dal;
using Dal.Repositories;
using Domain.Statistic;
using Domain.Url;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegistrationContainer(this IServiceCollection services)
        {
            services.AddSingleton<UrlContext>();
            services.AddTransient<IUrlRepository, UrlRepository>();
            services.AddHttpContextAccessor();
            services.AddTransient<IUrlService, UrlService>();
            services.AddTransient<IStatisticService, StatisticService>();
        }
    }
}