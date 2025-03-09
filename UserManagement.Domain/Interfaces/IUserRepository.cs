using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> ExistsByEmailAsync(string email);

        Task<User?> GetByIdAsync(string id);
        
        Task AddAsync(User user);

        Task<IEnumerable<User>> GetAllAsync();
    }
}
