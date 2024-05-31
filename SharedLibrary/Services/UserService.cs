using SharedLibrary.Helpers;
using SharedLibrary.Interface;
using SharedLibrary.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SharedLibrary.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly HashWrapper _hashHelper;

        public UserService(IUserRepository userRepository, HashWrapper hashHelper)
        {
            _userRepository = userRepository;
            _hashHelper = hashHelper;
        }

        public async Task EditUser(int userId, string username, string email, string imagePath, string? password, DateTime registrationDate, string userType, string bio = null, int? status = null, int? permission = null)
        {
            string emailPattern = @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$";

            if (!Regex.IsMatch(email, emailPattern))
            {
                throw new ArgumentException("Invalid email format.");
            }
            var user = _userRepository.GetUsers().FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            if (_userRepository.GetUsers().Any(u => (u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) || u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)) && u.UserId != userId))
            {
                throw new InvalidOperationException("Another user with the same username or email already exists.");
            }

            bool changesDetected = false;

            if (user.Username != username) { user.Username = username; changesDetected = true; }
            if (user.Email != email) { user.Email = email; changesDetected = true; }
            if (user.ImagePath != imagePath) { user.ImagePath = imagePath; changesDetected = true; }
            if (user.RegistrationDate != registrationDate) { user.RegistrationDate = registrationDate; changesDetected = true; }
            if (password != null)
            {
                byte[] salt = _hashHelper.GenerateSalt();
                string newPasswordHash = _hashHelper.HashPassword(password, salt);
                if (user.PasswordHash != newPasswordHash)
                {
                    user.PasswordHash = newPasswordHash;
                    user.Salt = Convert.ToBase64String(salt);
                    changesDetected = true;
                }
            }

            if (user is Admin admin)
            {
                if (permission.HasValue && admin.Permission != (Permission)permission.Value)
                {
                    admin.Permission = (Permission)permission.Value;
                    changesDetected = true;
                }
                await _userRepository.UpdateUser(admin);
            }
            else if (user is Client client)
            {
                if (bio != null && client.Bio != bio) { client.Bio = bio; changesDetected = true; }
                if (status.HasValue && client.Status != (Status)status.Value) { client.Status = (Status)status.Value; changesDetected = true; }
                await _userRepository.UpdateUser(client);
            }


            if (!changesDetected)
            {
                throw new Exception("No changes detected.");
            }
        }

        public async Task DeleteUser(int userId)
        {
            await _userRepository.DeleteUser(userId);
        }

        public List<dynamic> SearchUsers(string query)
        {
            return _userRepository.GetUsers()
                .Where(user => user.Username.Contains(query, StringComparison.OrdinalIgnoreCase))
                .Select(user => (dynamic)user)
                .ToList();
        }

        public dynamic? GetUserById(int userId)
        {
            var user = _userRepository.GetUsers().FirstOrDefault(u => u.UserId == userId);

            if (user != null)
            {
                if (user is Admin)
                {
                    return (Admin)user;
                }
                else if (user is Client)
                {
                    return (Client)user;
                }
            }

            return null;
        }

        public int GetTotalUsers()
        {
            return _userRepository.GetUsers().Count;
        }

        public int GetUsersCreatedToday()
        {
            return _userRepository.GetUsers().Count(u => u.RegistrationDate.Date == DateTime.Today);
        }

        public List<Admin> GetAllAdmins()
        {
            return _userRepository.GetUsers().OfType<Admin>().ToList();
        }
    }
}
