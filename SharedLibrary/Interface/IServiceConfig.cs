using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace SharedLibrary.Interface;

public interface IServiceConfig
{
    string ConnectionString { get; }
    IUserContext UserContext { get; }
}

public class WebServiceConfig : IServiceConfig
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public WebServiceConfig(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
    }

    public string ConnectionString => _configuration.GetConnectionString("DefaultConnection");
    public IUserContext UserContext => new WebUserContext(_httpContextAccessor);
}

public class WinFormServiceConfig : IServiceConfig
{
    private readonly string _connectionString;
    private readonly IUserContext _userContext;

    public WinFormServiceConfig(string connectionString, IUserContext userContext)
    {
        _connectionString = connectionString;
        _userContext = userContext;
    }

    public string ConnectionString => _connectionString;
    public IUserContext UserContext => _userContext;
}


