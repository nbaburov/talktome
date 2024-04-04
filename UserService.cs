using SharedLibrary.Models;
using SharedLibrary.Data;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace SharedLibrary.Services
{
    public class UserService
    {
        private readonly UserData _userData;
        private List<User> _users;
        public User CurrentlyLoggedInUser { get; private set; }

        public UserService(string connectionString)
        {
            _userData = new UserData(connectionString);
            _users = new List<User>();
            LoadUsersAsync().Wait(); // Wait for asynchronous operation to complete
        }

        //* Managing Data

        private async Task LoadUsersAsync()
        {
            var usersFromData = await _userData.GetAllUsers();
            _users.AddRange(usersFromData);
        }

        //* Crud Methods

        public async Task RegisterUser(string username, string email, string imagePath, string password, DateTime registrationDate, string userType, string bio = null, int? status = null, int? permission = null)
        {
            // Generate salt
            byte[] salt = GenerateSalt();

            // Hash the password with salt
            string passwordHash = HashPassword(password, salt);

            User newUser;
            if (userType.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                newUser = new Admin
                {
                    Username = username,
                    Email = email,
                    ImagePath = imagePath,
                    PasswordHash = passwordHash,
                    Salt = Convert.ToBase64String(salt),
                    RegistrationDate = registrationDate,
                    Permission = permission.HasValue ? (Permission)permission.Value : Permission.Basic
                };
            }
            else if (userType.Equals("Client", StringComparison.OrdinalIgnoreCase))
            {
                newUser = new Client
                {
                    Username = username,
                    Email = email,
                    ImagePath = imagePath,
                    PasswordHash = passwordHash,
                    Salt = Convert.ToBase64String(salt),
                    RegistrationDate = registrationDate,
                    Bio = bio,
                    Status = status.HasValue ? (Status)status.Value : Status.Active // Default to Active if null
                };
            }
            else
            {
                throw new ArgumentException("User type must be either 'Admin' or 'Client'.");
            }

            _users.Add(newUser);
            await _userData.AddUser(username, email, imagePath, passwordHash, Convert.ToBase64String(salt), registrationDate, userType, bio, status, permission);
        }


        public bool Login(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                // Hash the entered password with the salt stored in the database
                string enteredPasswordHash = HashPassword(password, Convert.FromBase64String(user.Salt));

                // Check if the entered hashed password matches the stored hashed password
                if (enteredPasswordHash == user.PasswordHash)
                {
                    CurrentlyLoggedInUser = user;
                    return true;
                }
            }

            return false;
        }


        public async Task EditUser(int userId, string username, string email, string imagePath, string password, DateTime registrationDate, string userType, string bio = null, int? status = null, int? permission = null)
        {
            var user = _users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                // Generate salt
                byte[] salt = GenerateSalt();

                // Hash the password with salt
                string passwordHash = HashPassword(password, salt);

                user.Username = username;
                user.Email = email;
                user.ImagePath = imagePath;
                user.PasswordHash = passwordHash;
                user.RegistrationDate = registrationDate;

                if (user is Admin admin)
                {
                    admin.Permission = permission.HasValue ? (Permission)permission.Value : admin.Permission;
                }
                else if (user is Client client)
                {
                    client.Bio = bio;
                    client.Status = status.HasValue ? (Status)status.Value : client.Status;
                }

                await _userData.UpdateUser(userId, username, email, imagePath, passwordHash, salt, registrationDate, userType, bio, status, permission);
            }
            else
            {
                throw new Exception("User not found.");
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
            else
            {
                throw new Exception("User not found.");
            }
        }

        //* Helper Methods

        // Method to generate random salt
        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        // Method to hash password with salt
        private string HashPassword(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(20); // 20-byte hash
                byte[] hashBytes = new byte[36]; // 16 bytes for salt + 20 bytes for hash
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);
                return Convert.ToBase64String(hashBytes);
            }
        }

    }
}
