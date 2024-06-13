using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Services;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace talktomeweb.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly AuthService _authService;

        [BindProperty]
        public InputModel Input { get; set; }

        public LoginModel(AuthService authService)
        {
            _authService = authService;
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
            if (_authService.CurrentlyLoggedInUser != null)
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

            try
            {
                var loginSuccess = _authService.LoginUser(
                    Input.Email,
                    Input.Password);

                if (loginSuccess)
                {
                    return RedirectToPage("/Index");
                }
                else
                {
                    throw new Exception("Login data invalid.");
                }
            }
            catch (Exception ex)
            {
                TempData["AlertTitle"] = "Error.";
                TempData["AlertText"] = ex.Message;
                TempData["AlertColor"] = "red";
                return Page();
            }

        }
    }
}
