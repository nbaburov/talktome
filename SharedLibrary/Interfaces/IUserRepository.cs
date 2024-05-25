using System.Collections.Generic;
using System.Threading.Tasks;
using SharedLibrary.Models;

namespace SharedLibrary.Interface
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int userId);
        IUserContext GetUserContext();
    }
}
