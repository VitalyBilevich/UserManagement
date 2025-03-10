using UserManagement.Domain.Interfaces;

namespace UserManagement.Application.Interfaces
{
    public interface IUserRepositoryFactory
    {
        IUserRepository Create(string repositoryType);
    }
}
