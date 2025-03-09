using UserManagement.Domain.Entities;

namespace UserManagement.Domain
{
    public interface IDataStorage
    {
        bool IsAvailable();

        
        void Save(User user);
        
        IEnumerable<User> RetrieveAll();
    }
}
