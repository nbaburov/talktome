using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Models;
using SharedLibrary.Services;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace talktomeweb.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserService _userService;

        [BindProperty]
        public InputModel Input { get; set; }

        public RegisterModel(UserService userService)
        {
            _userService = userService;
        }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            public required string Username { get; set; }

            [Required]
            [DataType(DataType.EmailAddress)]
            public required string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            public required string Password { get; set; }

            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public required string ConfirmPassword { get; set; }

            [DataType(DataType.Upload)]
            public required IFormFile Image { get; set; }

            [DataType(DataType.MultilineText)]
            public required string Bio { get; set; }

        }

        public IActionResult OnGet()
        {
            if (_userService.CurrentlyLoggedInUser != null)
            {
                return RedirectToPage("/Account/Manage");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string imagePath = ProcessUploadedFile(Input.Image);
            try
            {
                var registrationSuccess = await _userService.RegisterUserAsync(
                   Input.Username,
                   Input.Email,
                   imagePath,
                   Input.Password,
                   DateTime.UtcNow,
                   "Client",
                   Input.Bio,
                   (int?)Status.Active,
                   null);

                if (registrationSuccess)
                {
                    var loginSuccess = _userService.LoginUser(Input.Email, Input.Password);

                    if (loginSuccess)
                    {

                        return RedirectToPage("/Index");
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["AlertTitle"] = "Error.";
                TempData["AlertText"] = ex.Message;
                TempData["AlertColor"] = "red";
                return RedirectToPage("/Account/Register");
            }


            return RedirectToPage("/Account/Login");
        }

        private string ProcessUploadedFile(IFormFile file)
        {
            string uniqueFileName = null;

            if (file != null)
            {

                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/users");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
