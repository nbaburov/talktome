using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Models;
using SharedLibrary.Services;

namespace talktomeweb.Pages.Account
{
    public class ManageModel : PageModel
    {
        private readonly AuthService _authService;
        private readonly PostService _postService;
        public List<SharedLibrary.Models.Post> Posts { get; set; }

        public ManageModel(AuthService authService, PostService postService)
        {
            _authService = authService;
            _postService = postService;
        }

        public Client CurrentUser { get; private set; }

        public IActionResult OnGet()
        {
            CurrentUser = _authService.GetCurrentlyLoggedInUser();
            if (CurrentUser == null)
            {
                return RedirectToPage("/Index");
            }


            Posts = (List<SharedLibrary.Models.Post>)(_postService.GetAllPostsByUser(CurrentUser.UserId) ?? new List<SharedLibrary.Models.Post>());

            return Page();
        }

        public IActionResult OnPostLogout()
        {
            try
            {
                _authService.Logout();
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                TempData["AlertTitle"] = "Error.";
                TempData["AlertText"] = ex.Message;
                TempData["AlertColor"] = "red";
                return RedirectToPage("/Index");
            }
        }
    }
}
