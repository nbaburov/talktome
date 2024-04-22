using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Services;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace talktomeweb.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly UserService _userService;

        [BindProperty]
        public InputModel Input { get; set; }

        public LoginModel(UserService userService)
        {
            _userService = userService;
        }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public IActionResult OnGet()
        {
            if (_userService.CurrentlyLoggedInUser != null)
            {
                return RedirectToPage("/Account/Manage");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Console.WriteLine(Input.Password);
            var loginSuccess = _userService.LoginUser(
                Input.Email,
                Input.Password);

            // Console.WriteLine(loginSuccess);
            if (loginSuccess)
            {
                // var cookieOptions = new CookieOptions
                // {
                //     Expires = DateTime.Now.AddDays(7),
                //     HttpOnly = true,
                //     Secure = true,
                // };
                // Response.Cookies.Append("UserEmail", Input.Email, cookieOptions);
                return RedirectToPage("/Index");
            }
            else
            {
                return RedirectToPage("/Account/Login");
            }
        }
    }
}
