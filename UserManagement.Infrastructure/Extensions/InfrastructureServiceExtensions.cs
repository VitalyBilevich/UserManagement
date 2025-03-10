using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Data.InMemoryCache;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Application.Interfaces;
using UserManagement.Application.Configurations;
using UserManagement.Infrastructure.Caching;
using UserManagement.Application.Constants;

namespace UserManagement.Infrastructure.Extensions
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
            services.AddSingleton(typeof(IInMemoryCacheService<,>), typeof(InMemoryCacheService<,>));

            // CacheSettings from appsettings.json
            services.Configure<CacheSettings>(configuration.GetSection(CacheSettingsConfigNames.CacheSettings));

            services.AddSingleton<IInMemoryCacheServiceFactory, InMemoryCacheServiceFactory>();

            // Factory for creating an IUserRepository implementation based on a key.
            // It is planned that the Application will choose which one it prefers.
            // Factory is not needed if we do not want to provide a choice to the Application, but only want to replace the implementation without notifiying it.
            services.AddSingleton<IUserRepositoryFactory, UserRepositoryFactory>();

            return services;
        }
    }

}
