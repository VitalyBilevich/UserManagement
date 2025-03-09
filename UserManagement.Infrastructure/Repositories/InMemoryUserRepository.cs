using System.Collections.Concurrent;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces;

namespace UserManagement.Infrastructure.Repositories
{

    // We can't work with ConcurrentDictionary asynchronously, so we need to use Task.FromResult to return results.
    // This doesn't make it asynchronous, but it allows us to use the same interface as other repositories.
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly ConcurrentDictionary<string, User> _users = new();

        public Task<bool> ExistsByEmailAsync(string email) => Task.FromResult(_users.Values.Any(u => u.Email == email));

        public Task<User?> GetByIdAsync(string id) => Task.FromResult(_users.GetValueOrDefault(id));

        public Task AddAsync(User user)
        {
            _users[user.Id] = user;
            return Task.CompletedTask;
        }

        public Task<IEnumerable<User>> GetAllAsync() => Task.FromResult(_users.Values.AsEnumerable());
    }
}