using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Services;
using SharedLibrary.Models; // Assume this exists based on your project structure

namespace talktomeweb.Pages.Account
{
    public class ProfileModel : PageModel
    {
        private readonly UserService _userService;

        public dynamic SelectedUser { get; private set; }

        public ProfileModel(UserService userService)
        {
            _userService = userService;
        }

        public void OnGet(int userId)
        {
            SelectedUser = _userService.GetUserById(userId);
        }
    }
}
