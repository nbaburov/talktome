using Microsoft.AspNetCore.Http;
using SharedLibrary.Models;

namespace SharedLibrary.Interface
{
    public interface IUserContext
    {
        string GetCurrentUserEmail();
        void SetCurrentUserEmail(string email);
        void ClearCurrentUserEmail();
    }

    public class WebUserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WebUserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUserEmail()
        {
            return _httpContextAccessor.HttpContext.Request.Cookies["UserEmail"];
        }

        public void SetCurrentUserEmail(string email)
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7),
                HttpOnly = true,
                Secure = true,
            };
            _httpContextAccessor.HttpContext.Response.Cookies.Append("UserEmail", email, cookieOptions);
        }

        public void ClearCurrentUserEmail()
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("UserEmail");
        }
    }


    public class WinFormUserContext : IUserContext
    {
        private string? _currentUserEmail;

        public string GetCurrentUserEmail()
        {
            return _currentUserEmail;
        }

        public void SetCurrentUserEmail(string email)
        {
            _currentUserEmail = email;
        }

        public void ClearCurrentUserEmail()
        {
            _currentUserEmail = null;
        }
    }

}


