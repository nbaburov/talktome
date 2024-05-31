using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq; 
// Moq lets you simulate the behavior of dependencies, so you can test a class in isolation without relying on real implementations.
// can define specific behaviors and return values for methods of the mocked dependencies, making tests predictable and consistent.
using SharedLibrary.Helpers;
using SharedLibrary.Interface;
using SharedLibrary.Models;
using SharedLibrary.Repository;
using SharedLibrary.Services;

namespace talktometest
{
    [TestClass]
    public class UserServiceTests
    {
        private UserService _userService;
        private TestUserRepository _testUserRepository;
        private Mock<HashWrapper> _hashHelperMock;
        private Mock<IUserContext> _userContextMock;

        [TestInitialize]
        public void Setup()
        {
            // Access the Mocked Instance: The .Object property is used to get the instance of the mock that implements the interface or class. This instance is what you pass to the class under test.
            _userContextMock = new Mock<IUserContext>();
            _testUserRepository = new TestUserRepository(_userContextMock.Object);
            _hashHelperMock = new Mock<HashWrapper>();
            _userService = new UserService(_testUserRepository, _hashHelperMock.Object);
        }

        [TestMethod]
        public async Task EditUser_ValidUser_ChangesDetected_ReturnsTrue()
        {
            // Arrange
            var user = new Client
            {
                UserId = 1,
                Username = "testuser",
                Email = "test@example.com",
                PasswordHash = "oldhash",
                Salt = Convert.ToBase64String(new byte[] { 1, 2, 3, 4 }),
                RegistrationDate = DateTime.UtcNow,
                Bio = "Old Bio",
                Status = Status.Active
            };
            await _testUserRepository.AddUser(user);

            var newUsername = "updateduser";
            var newEmail = "updated@example.com";
            var newImagePath = "newpath";
            var newPassword = "newpassword";
            var newRegistrationDate = DateTime.UtcNow;
            var newBio = "New Bio";
            var newStatus = (int)Status.Suspended;

            _hashHelperMock.Setup(h => h.GenerateSalt()).Returns(new byte[] { 5, 6, 7, 8 });
            // In Moq, It is a static class that provides a set of helper methods for creating parameter matchers.
            // It.IsAny<T>() is a specific matcher provided by the It class that matches any value of type T. This means that when you use It.IsAny<T>() in your mock setup or verification, it will accept any value of the specified type for that parameter.
            // Setup the mock to return "newhash" whenever HashPassword is called with 'newPassword' and any byte array as parameters.
            _hashHelperMock.Setup(h => h.HashPassword(newPassword, It.IsAny<byte[]>())).Returns("newhash");

            // Act
            await _userService.EditUser(user.UserId, newUsername, newEmail, newImagePath, newPassword, newRegistrationDate, "Client", newBio, newStatus);

            // Assert
            var updatedUser = _testUserRepository.GetUsers().FirstOrDefault(u => u.UserId == user.UserId);
            Assert.IsNotNull(updatedUser);
            Assert.AreEqual(newUsername, updatedUser.Username);
            Assert.AreEqual(newEmail, updatedUser.Email);
            Assert.AreEqual(newImagePath, updatedUser.ImagePath);
            Assert.AreEqual("newhash", updatedUser.PasswordHash);
            Assert.AreEqual("New Bio", ((Client)updatedUser).Bio);
            Assert.AreEqual(Status.Suspended, ((Client)updatedUser).Status);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task EditUser_InvalidEmailFormat_ThrowsArgumentException()
        {
            // Arrange
            var user = new Client
            {
                UserId = 1,
                Username = "testuser",
                Email = "test@example.com",
                PasswordHash = "oldhash",
                Salt = Convert.ToBase64String(new byte[] { 1, 2, 3, 4 }),
                RegistrationDate = DateTime.UtcNow,
                Bio = "Old Bio",
                Status = Status.Active
            };
            await _testUserRepository.AddUser(user);

            var invalidEmail = "invalidemail";

            // Act
            await _userService.EditUser(user.UserId, user.Username, invalidEmail, user.ImagePath, null, user.RegistrationDate, "Client", user.Bio, (int)user.Status);
        }

        [TestMethod]
        public async Task DeleteUser_ValidUserId_DeletesUser()
        {
            // Arrange
            var user = new Client
            {
                UserId = 1,
                Username = "testuser",
                Email = "test@example.com",
                PasswordHash = "hash",
                Salt = Convert.ToBase64String(new byte[] { 1, 2, 3, 4 }),
                RegistrationDate = DateTime.UtcNow,
                Bio = "Bio",
                Status = Status.Active
            };
            await _testUserRepository.AddUser(user);

            // Act
            await _userService.DeleteUser(user.UserId);

            // Assert
            var deletedUser = _testUserRepository.GetUsers().FirstOrDefault(u => u.UserId == user.UserId);
            Assert.IsNull(deletedUser);
        }

        [TestMethod]
        public void SearchUsers_ValidQuery_ReturnsMatchingUsers()
        {
            // Arrange
            var user1 = new Client
            {
                UserId = 1,
                Username = "testuser1",
                Email = "test1@example.com",
                PasswordHash = "hash1",
                Salt = Convert.ToBase64String(new byte[] { 1, 2, 3, 4 }),
                RegistrationDate = DateTime.UtcNow,
                Bio = "Bio1",
                Status = Status.Active
            };

            var user2 = new Admin
            {
                UserId = 2,
                Username = "testuser2",
                Email = "test2@example.com",
                PasswordHash = "hash2",
                Salt = Convert.ToBase64String(new byte[] { 1, 2, 3, 4 }),
                RegistrationDate = DateTime.UtcNow,
                Permission = Permission.Basic
            };

            _testUserRepository.AddUser(user1).Wait(); // Ensure its done before moving on
            _testUserRepository.AddUser(user2).Wait();

            // Act
            var result = _userService.SearchUsers("test");

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetUserById_ValidUserId_ReturnsUser()
        {
            // Arrange
            var user = new Client
            {
                UserId = 1,
                Username = "testuser",
                Email = "test@example.com",
                PasswordHash = "hash",
                Salt = Convert.ToBase64String(new byte[] { 1, 2, 3, 4 }),
                RegistrationDate = DateTime.UtcNow,
                Bio = "Bio",
                Status = Status.Active
            };
            _testUserRepository.AddUser(user).Wait();

            // Act
            var result = _userService.GetUserById(user.UserId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(user.UserId, result.UserId);
        }

        [TestMethod]
        public void GetTotalUsers_ReturnsCorrectCount()
        {
            // Arrange
            var user1 = new Client
            {
                UserId = 1,
                Username = "testuser1",
                Email = "test1@example.com",
                PasswordHash = "hash1",
                Salt = Convert.ToBase64String(new byte[] { 1, 2, 3, 4 }),
                RegistrationDate = DateTime.UtcNow,
                Bio = "Bio1",
                Status = Status.Active
            };

            var user2 = new Admin
            {
                UserId = 2,
                Username = "testuser2",
                Email = "test2@example.com",
                PasswordHash = "hash2",
                Salt = Convert.ToBase64String(new byte[] { 1, 2, 3, 4 }),
                RegistrationDate = DateTime.UtcNow,
                Permission = Permission.Basic
            };

            _testUserRepository.AddUser(user1).Wait();
            _testUserRepository.AddUser(user2).Wait();

            // Act
            var result = _userService.GetTotalUsers();

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void GetUsersCreatedToday_ReturnsCorrectCount()
        {
            // Arrange
            var user1 = new Client
            {
                UserId = 1,
                Username = "testuser1",
                Email = "test1@example.com",
                PasswordHash = "hash1",
                Salt = Convert.ToBase64String(new byte[] { 1, 2, 3, 4 }),
                RegistrationDate = DateTime.UtcNow,
                Bio = "Bio1",
                Status = Status.Active
            };

            var user2 = new Admin
            {
                UserId = 2,
                Username = "testuser2",
                Email = "test2@example.com",
                PasswordHash = "hash2",
                Salt = Convert.ToBase64String(new byte[] { 1, 2, 3, 4 }),
                RegistrationDate = DateTime.UtcNow.AddDays(-1),
                Permission = Permission.Basic
            };

            _testUserRepository.AddUser(user1).Wait();
            _testUserRepository.AddUser(user2).Wait();

            // Act
            var result = _userService.GetUsersCreatedToday();

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetAllAdmins_ReturnsCorrectAdmins()
        {
            // Arrange
            var user1 = new Client
            {
                UserId = 1,
                Username = "testuser1",
                Email = "test1@example.com",
                PasswordHash = "hash1",
                Salt = Convert.ToBase64String(new byte[] { 1, 2, 3, 4 }),
                RegistrationDate = DateTime.UtcNow,
                Bio = "Bio1",
                Status = Status.Active
            };

            var user2 = new Admin
            {
                UserId = 2,
                Username = "testuser2",
                Email = "test2@example.com",
                PasswordHash = "hash2",
                Salt = Convert.ToBase64String(new byte[] { 1, 2, 3, 4 }),
                RegistrationDate = DateTime.UtcNow,
                Permission = Permission.Basic
            };

            _testUserRepository.AddUser(user1).Wait();
            _testUserRepository.AddUser(user2).Wait();

            // Act
            var result = _userService.GetAllAdmins();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(user2.UserId, result.First().UserId);
        }
    }
}
