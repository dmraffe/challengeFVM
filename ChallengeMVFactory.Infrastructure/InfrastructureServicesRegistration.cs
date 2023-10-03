using ChallengeMVFactory.Application.Contracts.ExternalApi;
using ChallengeMVFactory.Application.Contracts.Persistence;
using ChallengeMVFactory.Infrastructure.External;
using ChallengeMVFactory.Infrastructure.Persistence;
using ChallengeMVFactory.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ChallengeMVFactory.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MVFactoryDbContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IHistoryWatherRepository, HistoryWatherRepository>();
            services.AddScoped<ICountryExternalApi, CountryExternalApi>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IWeatherExternalApi, WeatherExternalApi>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddTransient<DataSeeder>();



            return services;
        }
    }
}
