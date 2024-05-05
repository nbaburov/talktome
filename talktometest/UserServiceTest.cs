namespace talktometest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SharedLibrary.Services;
using SharedLibrary.Interface;
using SharedLibrary.Models;
using System;
using System.Threading.Tasks;
using SharedLibrary.Data;

[TestClass]
public class UserServiceTests
{
    private UserServiceTest _userService;
    private Mock<IServiceConfig> _mockConfig;
    private Mock<IUserContext> _mockUserContext;
    private Dictionary<int, User> _userDataStore;

    [TestInitialize]
    public void Initialize()
    {
        _userDataStore = new Dictionary<int, User>();
        _mockUserContext = new Mock<IUserContext>();
        _mockConfig = new Mock<IServiceConfig>();
        _mockConfig.Setup(config => config.UserContext).Returns(_mockUserContext.Object);

        _userService = new UserServiceTest(_mockConfig.Object, _userDataStore);
        SeedUserData();
    }

    private void SeedUserData()
    {
        var admin = new Admin
        {
            UserId = 3,
            Username = "admin",
            Email = "admin@email.com",
            Salt = Convert.ToBase64String(new byte[16]),
            PasswordHash = _userService.HashPassword("adminpass", new byte[16]),
            Permission = Permission.Full
        };
        var client = new Client
        {
            UserId = 4,
            Username = "client",
            Email = "client@email.com",
            Salt = Convert.ToBase64String(new byte[16]),
            PasswordHash = _userService.HashPassword("clientpass", new byte[16]),
            Status = Status.Active
        };

        _userDataStore.Add(admin.UserId, admin);
        _userDataStore.Add(client.UserId, client);
        _userService.LoadAllDataAsync().Wait();
    }

    [TestMethod]
    public async Task RegisterAdminAsync_ValidUser_ReturnsTrue()
    {
        var result = await _userService.RegisterUserAsync("testuser", "test@email.com", "path/to/image", "password", DateTime.Now, "Client", null, null, null);
        Assert.IsTrue(result);
        Assert.AreEqual(3, _userDataStore.Count);
    }

    [TestMethod]
    public async Task RegisterUserAsync_ValidUser_ReturnsTrue()
    {
        var result = await _userService.RegisterUserAsync("testadmin", "test@email.com", "path/to/image", "password", DateTime.Now, "Admin", null, null, null);
        Assert.IsTrue(result);
        Assert.AreEqual(3, _userDataStore.Count);
    }

    [TestMethod]
    public void LoginUser_ValidCredentials_ReturnsTrue()
    {
        var result = _userService.LoginUser("admin@email.com", "adminpass");
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void LoginAdmin_ValidCredentials_ReturnsTrue()
    {
        var result = _userService.LoginAdmin("admin@email.com", "adminpass");
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void GetAllAdmins_ReturnsOnlyAdmins()
    {
        var admins = _userService.GetAllAdmins();
        Assert.AreEqual(1, admins.Count);
    }
}
