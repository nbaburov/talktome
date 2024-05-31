using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Services;
using SharedLibrary.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;

namespace talktomeweb.Pages.Account
{
    public class EditProfileModel : PageModel
    {
        private readonly UserService _userService;
        private readonly AuthService _authService;
        public dynamic CurrentUser { get; private set; }
        public dynamic imagePath { get; set; }
        private dynamic passwordChange { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public EditProfileModel(UserService userService, AuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        public class InputModel
        {
            public string Username { get; set; }

            [EmailAddress]
            public string Email { get; set; }

            public IFormFile Image { get; set; }

            public string Bio { get; set; }

            public string Password { get; set; }
        }


        public IActionResult OnGet()
        {

            ModelState.Clear();

            CurrentUser = _authService.GetCurrentlyLoggedInUser();
            if (CurrentUser == null)
            {
                return RedirectToPage("/Account/Register");
            }

            imagePath = CurrentUser.ImagePath;

            Input = new InputModel
            {
                Username = CurrentUser.Username,
                Email = CurrentUser.Email,
                Bio = CurrentUser.Bio,
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            ModelState.Remove("Input.Password");
            ModelState.Remove("Input.Image");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            CurrentUser = _authService.GetCurrentlyLoggedInUser();
            if (CurrentUser == null)
            {
                return RedirectToPage("/Account/Register");
            }

            string imagePath = Input.Image != null ? ProcessUploadedFile(Input.Image) : CurrentUser.ImagePath;

            string passwordChange = string.IsNullOrEmpty(Input.Password) ? null : Input.Password;
            Console.Write(passwordChange);
            try
            {

                await _userService.EditUser(CurrentUser.UserId, Input.Username, Input.Email, imagePath, passwordChange, CurrentUser.RegistrationDate, CurrentUser is Admin ? "Admin" : "Client", Input.Bio, (int)CurrentUser.Status);

            }
            catch (Exception ex)
            {
                TempData["AlertTitle"] = "Error.";
                TempData["AlertText"] = ex.Message;
                TempData["AlertColor"] = "red";
                return RedirectToPage("/Account/EditProfile");
            }

            return RedirectToPage("/Account/Manage");
        }

        private string ProcessUploadedFile(IFormFile file)
        {
            string uniqueFileName = null;
            try
            {

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
            catch (Exception ex)
            {
                TempData["AlertTitle"] = "Error.";
                TempData["AlertText"] = ex.Message;
                TempData["AlertColor"] = "red";

                return uniqueFileName;
            }

        }
    }
}
