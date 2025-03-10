using Data.InMemoryCache;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Domain.Interfaces;
using UserManagement.Application.Interfaces;
using UserManagement.Application.Constants;
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

        public IUserRepository Create(string repositoryType)
        {
            return repositoryType switch
            {
                UserRepositoryTypes.InMemoryCache =>
                 new InMemoryCacheUserRepository(
                    _serviceProvider.GetRequiredService<IInMemoryCacheServiceFactory>(),
                    _serviceProvider.GetRequiredService<IOptions<CacheSettings>>()
                ),
                UserRepositoryTypes.InMemory => new InMemoryUserRepository(),
                _ => throw new ArgumentException($"Invalid User repository type: {repositoryType}")
            };
        }
    }
}
