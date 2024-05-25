using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedLibrary.Interface;
using SharedLibrary.Models;
using SharedLibrary.Repository;

namespace talktometest
{
    public class TestUserRepository : IUserRepository
    {
        private readonly Dictionary<int, User> _users;
        private readonly IUserContext _userContext;
        private int _nextId;

        public TestUserRepository(IUserContext userContext)
        {
            _users = new Dictionary<int, User>();
            _userContext = userContext;
            _nextId = 1;
        }

        public List<User> GetUsers()
        {
            return _users.Values.ToList();
        }

        public async Task AddUser(User user)
        {
            user.UserId = _nextId++;
            _users.Add(user.UserId, user);
            await Task.CompletedTask;
        }

        public async Task UpdateUser(User user)
        {
            if (_users.ContainsKey(user.UserId))
            {
                _users[user.UserId] = user;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteUser(int userId)
        {
            if (_users.ContainsKey(userId))
            {
                _users.Remove(userId);
            }
            await Task.CompletedTask;
        }

        public IUserContext GetUserContext()
        {
            return _userContext;
        }
    }
}
