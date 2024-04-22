using SharedLibrary.Models;
using SharedLibrary.Data;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;


namespace SharedLibrary.Services
{
    public class UserService
    {
        private readonly UserData _userData;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private List<User> _users;
        public User? CurrentlyLoggedInUser { get; private set; }

        public UserService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            _userData = new UserData(connectionString);
            _users = new List<User>();
            _httpContextAccessor = httpContextAccessor;
            LoadAllDataAsync().Wait();
            CheckAndSetCurrentlyLoggedInUserFromCookie();
        }

        //* Managing Data

        private void CheckAndSetCurrentlyLoggedInUserFromCookie()
        {
            var emailCookie = _httpContextAccessor.HttpContext.Request.Cookies["UserEmail"];
            if (!string.IsNullOrEmpty(emailCookie))
            {
                var user = _users.FirstOrDefault(u => u.Email == emailCookie);
                if (user != null)
                {
                    CurrentlyLoggedInUser = user;
                }
            }
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


        //* Crud Methods

        public async Task<bool> RegisterUserAsync(string username, string email, string imagePath, string password, DateTime registrationDate, string userType, string bio = null, int? status = null, int? permission = null)
        {
            try
            {
                byte[] salt = GenerateSalt();

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
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public bool LoginUser(string email, string password)
        {
            var user = _users.FirstOrDefault(u => u.Email == email);

            if (user != null)
            {
                string enteredPasswordHash = HashPassword(password, Convert.FromBase64String(user.Salt));

                if (enteredPasswordHash == user.PasswordHash)
                {
                    CurrentlyLoggedInUser = user;
                    return true;
                }
            }

            return false;
        }

        public void Logout()
        {
            CurrentlyLoggedInUser = null;

            _httpContextAccessor.HttpContext.Response.Cookies.Delete("UserEmail");
        }



        public async Task EditUser(int userId, string username, string email, string imagePath, string? password, DateTime registrationDate, string userType, string bio = null, int? status = null, int? permission = null)
        {
            var user = _users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                if (password != null)
                {
                    byte[] salt = GenerateSalt();

                    string passwordHash = HashPassword(password, salt);
                    user.PasswordHash = passwordHash;
                    user.Salt = Convert.ToBase64String(salt);
                }

                user.Username = username;
                user.Email = email;
                user.ImagePath = imagePath;

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

                await _userData.UpdateUser(userId, username, email, imagePath, user.PasswordHash, user.Salt, registrationDate, userType, bio, status, permission);
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

        public List<dynamic> SearchUsers(string query)
        {
            return _users
                .Where(user => user.Username.Contains(query, StringComparison.OrdinalIgnoreCase))
                .Select(user => (dynamic)user)
                .ToList();
        }


        public dynamic? GetCurrentlyLoggedInUser()
        {
            if (CurrentlyLoggedInUser is Admin)
            {
                return CurrentlyLoggedInUser as Admin;
            }
            else if (CurrentlyLoggedInUser is Client)
            {
                return CurrentlyLoggedInUser as Client;
            }
            else
            {
                return null;
            }
        }

        public dynamic? GetUserById(int userId)
        {
            var user = _users.FirstOrDefault(u => u.UserId == userId);

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


        //* Helper Methods

        // Method to generate random salt
        private byte[] GenerateSalt()
        {
            // Create an array of bytes to store the salt
            byte[] salt = new byte[16];

            // Use RNGCryptoServiceProvider to generate random bytes for the salt
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt); // Fill the salt array with random bytes
            }

            return salt; // Return the generated salt
        }

        // Method to hash password with salt
        private string HashPassword(string password, byte[] salt)
        {
            // Create an instance of Rfc2898DeriveBytes to hash the password using PBKDF2 algorithm
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(20); // Generate a 20-byte hash using PBKDF2
                byte[] hashBytes = new byte[36]; // Create an array to store the combined salt and hash bytes

                // Copy the salt bytes to the beginning of the hashBytes array
                Array.Copy(salt, 0, hashBytes, 0, 16);

                // Copy the hash bytes to the end of the hashBytes array
                Array.Copy(hash, 0, hashBytes, 16, 20);

                // Convert the combined salt and hash bytes to a base64-encoded string
                return Convert.ToBase64String(hashBytes);
            }
        }

    }
}
