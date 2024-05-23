using SharedLibrary.Models;
using SharedLibrary.Data;
using Newtonsoft.Json;
using SharedLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedLibrary.Repository
{
    public class UserRepository
    {
        private readonly UserData _userData;
        private readonly IUserContext _userContext;
        private List<User> _users;

        public UserRepository(IServiceConfig config)
        {
            string connectionString = config.ConnectionString;
            _userData = new UserData(connectionString);
            _userContext = config.UserContext;
            _users = new List<User>();

            LoadAllDataAsync().Wait();
        }

        private async Task LoadAllDataAsync()
        {
            var usersFromData = await _userData.GetAllUsers();
            foreach (var userData in usersFromData)
            {
                dynamic userObject = JsonConvert.DeserializeObject(userData);

                string userType = userObject.UserType;
                if (userType.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    var adminUser = JsonConvert.DeserializeObject<Admin>(userData);
                    _users.Add(adminUser);
                }
                else if (userType.Equals("Client", StringComparison.OrdinalIgnoreCase))
                {
                    var clientUser = JsonConvert.DeserializeObject<Client>(userData);
                    _users.Add(clientUser);
                }
            }
        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public async Task AddUser(User user)
        {
            _users.Add(user);
            if (user is Admin admin)
            {
                await _userData.AddUser(
                    admin.Username,
                    admin.Email,
                    admin.ImagePath,
                    admin.PasswordHash,
                    admin.Salt,
                    admin.RegistrationDate,
                    "Admin",
                    null,
                    null,
                    (int?)admin.Permission
                    );
            }
            else if (user is Client client)
            {
                await _userData.AddUser(
                    client.Username,
                    client.Email,
                    client.ImagePath,
                    client.PasswordHash,
                    client.Salt,
                    client.RegistrationDate,
                    "Client",
                    client.Bio,
                    (int?)client.Status,
                    null
                    );
            }
        }

        public async Task UpdateUser(User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.UserId == user.UserId);
            if (existingUser != null)
            {
                if (existingUser is Admin admin)
                {
                    existingUser.Username = admin.Username;
                    existingUser.Email = admin.Email;
                    existingUser.ImagePath = admin.ImagePath;
                    existingUser.PasswordHash = admin.PasswordHash;
                    existingUser.Salt = admin.Salt;
                    existingUser.RegistrationDate = admin.RegistrationDate;
                    admin.Permission = admin.Permission;

                    await _userData.UpdateUser(
                        admin.UserId,
                        admin.Username,
                        admin.Email,
                        admin.ImagePath,
                        admin.PasswordHash,
                        admin.Salt,
                        admin.RegistrationDate,
                        "Admin",
                        null,
                        null,
                        (int?)admin.Permission
                        );
                }
                else if (existingUser is Client client)
                {
                    existingUser.Username = client.Username;
                    existingUser.Email = client.Email;
                    existingUser.ImagePath = client.ImagePath;
                    existingUser.PasswordHash = client.PasswordHash;
                    existingUser.Salt = client.Salt;
                    existingUser.RegistrationDate = client.RegistrationDate;
                    client.Bio = client.Bio;
                    client.Status = client.Status;

                    await _userData.UpdateUser(
                        client.UserId,
                        client.Username,
                        client.Email,
                        client.ImagePath,
                        client.PasswordHash,
                        client.Salt,
                        client.RegistrationDate,
                        "Client",
                        client.Bio,
                        (int?)client.Status,
                        null
                        );
                }

            }
        }

        public async Task DeleteUser(int userId)
        {
            var user = _users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                _users.Remove(user);
                await _userData.DeleteUser(userId);
            }
        }

        public IUserContext GetUserContext()
        {
            return _userContext;
        }
    }
}
