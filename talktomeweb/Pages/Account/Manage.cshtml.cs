using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Models;
using SharedLibrary.Services;

namespace talktomeweb.Pages.Account
{
    public class ManageModel : PageModel
    {
        private readonly UserService _userService;

        public ManageModel(UserService userService)
        {
            _userService = userService;
        }

        public dynamic CurrentUser { get; private set; }

        public IActionResult OnGet()
        {
            CurrentUser = _userService.GetCurrentlyLoggedInUser();
            if (CurrentUser == null)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }

        public IActionResult OnPostLogout()
        {
            _userService.Logout();
            return RedirectToPage("/Index");
        }
    }
}
