using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces;
using Data.InMemoryCache;
using Microsoft.Extensions.Options;
using UserManagement.Application.Configurations;

namespace UserManagement.Infrastructure.Repositories
{
    // The memory cache(IInMemoryCacheService) is synchronous, so we need to use Task.FromResult to return results.
    // This doesn't make is async, but it allows us to use the same interface as other repositories.
    // This class is adapter for the InMemoryCacheService to implement the IUserRepository interface.
    public class InMemoryCacheUserRepository: IUserRepository
    {
        private readonly IInMemoryCacheService<string, User> _cache;

        public InMemoryCacheUserRepository(IInMemoryCacheServiceFactory cacheFactory, IOptions<CacheSettings> cacheSettings)           
        {
            string tableName = cacheSettings.Value.UserTable;
            _cache = cacheFactory.Create<string, User>(tableName, "");
        }

        public Task<bool> ExistsByEmailAsync(string email) => Task.FromResult(_cache.GetAll().Any(i => i.Email.Equals(email, StringComparison.OrdinalIgnoreCase)));

        public Task<User?> GetByIdAsync(string id) => Task.FromResult(_cache.GetById(id));       

        public Task<IEnumerable<User>> GetAllAsync() => Task.FromResult(_cache.GetAll());

        public Task AddAsync(User user)
        {
            _cache.AddOrUpdate(user.Id, user);
            return Task.CompletedTask;
        }
       
    }
}
