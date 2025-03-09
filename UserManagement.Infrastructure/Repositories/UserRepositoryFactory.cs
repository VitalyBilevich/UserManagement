using Data.InMemoryCache;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Domain.Interfaces;
using UserManagement.Application.Interfaces;
using UserManagement.Application.Configurations;

namespace UserManagement.Infrastructure.Repositories
{
    public class UserRepositoryFactory : IUserRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public UserRepositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IUserRepository Create(string key)
        {
            return key switch
            {
                "InMemoryCache" =>
                 new InMemoryCacheUserRepository(
                    _serviceProvider.GetRequiredService<IInMemoryCacheServiceFactory>(),
                    _serviceProvider.GetRequiredService<IOptions<CacheSettings>>()
                ),


                "InMemory" => new InMemoryUserRepository(),
                _ => throw new ArgumentException($"Invalid User repository type: {key}")
            };
        }
    }
}
