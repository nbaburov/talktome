using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Models;
using SharedLibrary.Services;

namespace talktomeweb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserService _userService;
        private readonly PostService _postService;
        public List<SharedLibrary.Models.Post> Posts { get; set; }
        public List<Category> Categories { get; set; }

        public IndexModel(ILogger<IndexModel> logger, UserService userService, PostService postService)
        {
            _logger = logger;
            _userService = userService;
            _postService = postService;
        }

        public dynamic CurrentUser { get; private set; }

        public IActionResult OnGet()
        {
            Posts = _postService.Posts;
            Categories = _postService.Categories;
            CurrentUser = _userService.GetCurrentlyLoggedInUser();
            // if (CurrentUser == null)
            // {
            //     return RedirectToPage("/Account/Register");
            // }

            return Page();
        }
    }
}
