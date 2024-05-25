using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SharedLibrary.Helpers;
using SharedLibrary.Interface;
using SharedLibrary.Models;
using SharedLibrary.Repository;
using SharedLibrary.Services;

namespace talktometest
{
    [TestClass]
    public class AuthServiceTests
    {
        private AuthService _authService;
        private TestUserRepository _testUserRepository;
        private Mock<HashWrapper> _hashHelperMock;
        private Mock<IUserContext> _userContextMock;

        [TestInitialize]
        public void Setup()
        {
            _userContextMock = new Mock<IUserContext>();
            _testUserRepository = new TestUserRepository(_userContextMock.Object);
            _hashHelperMock = new Mock<HashWrapper>();
            _authService = new AuthService(_testUserRepository, _hashHelperMock.Object);
        }

        [TestMethod]
        public async Task RegisterUserAsync_ValidUser_ReturnsTrue()
        {
            // Arrange
            var username = "testuser";
            var email = "test@example.com";
            var password = "password";
            var registrationDate = DateTime.UtcNow;
            var salt = new byte[] { 1, 2, 3, 4 };
            var passwordHash = "hashedpassword";

            _hashHelperMock.Setup(h => h.GenerateSalt()).Returns(salt);
            _hashHelperMock.Setup(h => h.HashPassword(password, salt)).Returns(passwordHash);

            // Act
            var result = await _authService.RegisterUserAsync(username, email, null, password, registrationDate, "Client");

            // Assert
            Assert.IsTrue(result);
            var user = _testUserRepository.GetUsers().FirstOrDefault();
            Assert.IsNotNull(user);
            Assert.AreEqual(username, user.Username);
            Assert.AreEqual(email, user.Email);
            Assert.AreEqual(passwordHash, user.PasswordHash);
        }

        [TestMethod]
        public void LoginUser_ValidCredentials_ReturnsTrue()
        {
            // Arrange
            var username = "testuser";
            var email = "test@example.com";
            var password = "password";
            var salt = Convert.ToBase64String(new byte[] { 1, 2, 3, 4 });
            var passwordHash = "hashedpassword";

            var user = new Client
            {
                Username = username,
                Email = email,
                Salt = salt,
                PasswordHash = passwordHash,
                RegistrationDate = DateTime.UtcNow
            };

            _testUserRepository.AddUser(user).Wait();

            _hashHelperMock.Setup(h => h.HashPassword(password, Convert.FromBase64String(salt))).Returns(passwordHash);

            // Act
            var result = _authService.LoginUser(email, password);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNotNull(_authService.CurrentlyLoggedInUser);
            Assert.AreEqual(email, _authService.CurrentlyLoggedInUser.Email);
        }

        [TestMethod]
        public void LoginUser_InvalidCredentials_ReturnsFalse()
        {
            // Arrange
            var email = "invalid@example.com";
            var password = "password";

            // Act
            var result = _authService.LoginUser(email, password);

            // Assert
            Assert.IsFalse(result);
            Assert.IsNull(_authService.CurrentlyLoggedInUser);
        }
    }
}
