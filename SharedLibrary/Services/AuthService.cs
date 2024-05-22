using SharedLibrary.Helpers;
using SharedLibrary.Models;
using SharedLibrary.Repository;
using System.Text.RegularExpressions;

namespace SharedLibrary.Services
{
    public class AuthService
    {
        private readonly UserRepository _userRepository;
        private readonly Hash _hashHelper;
        public User? CurrentlyLoggedInUser { get; private set; }

        public AuthService(UserRepository userRepository, Hash hashHelper)
        {
            _userRepository = userRepository;
            _hashHelper = hashHelper;
            CheckAndSetCurrentlyLoggedInUser();
        }

        private void CheckAndSetCurrentlyLoggedInUser()
        {
            var email = _userRepository.GetUserContext().GetCurrentUserEmail();
            if (!string.IsNullOrEmpty(email))
            {
                var user = _userRepository.GetUsers().FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    CurrentlyLoggedInUser = user;
                }
            }
        }

        public async Task<bool> RegisterUserAsync(string username, string email, string imagePath, string password, DateTime registrationDate, string userType, string bio = null, int? status = null, int? permission = null)
        {
            string emailPattern = @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$";

            if (!Regex.IsMatch(email, emailPattern))
            {
                throw new ArgumentException("Invalid email format.");
            }
            if (_userRepository.GetUsers().Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) || u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("A user with the same username or email already exists.");
            }
            try
            {
                byte[] salt = _hashHelper.GenerateSalt();
                string passwordHash = _hashHelper.HashPassword(password, salt);

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
                        Status = status.HasValue ? (Status)status.Value : Status.Active
                    };
                }
                else
                {
                    throw new ArgumentException("User type must be either 'Admin' or 'Client'.");
                }

                await _userRepository.AddUser(newUser);
                _userRepository.GetUserContext().SetCurrentUserEmail(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool LoginUser(string email, string password)
        {
            var user = _userRepository.GetUsers().FirstOrDefault(u => u.Email == email);

            if (user != null && !(user is Admin))
            {
                string enteredPasswordHash = _hashHelper.HashPassword(password, Convert.FromBase64String(user.Salt));

                if (enteredPasswordHash == user.PasswordHash)
                {
                    CurrentlyLoggedInUser = user;
                    _userRepository.GetUserContext().SetCurrentUserEmail(email);
                    return true;
                }
            }

            return false;
        }

        public bool LoginAdmin(string email, string password)
        {
            var user = _userRepository.GetUsers().FirstOrDefault(u => u.Email == email);

            if (user != null && user is Admin admin)
            {
                string enteredPasswordHash = _hashHelper.HashPassword(password, Convert.FromBase64String(admin.Salt));

                if (enteredPasswordHash == admin.PasswordHash)
                {
                    CurrentlyLoggedInUser = admin;
                    _userRepository.GetUserContext().SetCurrentUserEmail(email);
                    return true;
                }
            }

            return false;
        }

        public void Logout()
        {
            CurrentlyLoggedInUser = null;
            _userRepository.GetUserContext().ClearCurrentUserEmail();
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
    }
}
