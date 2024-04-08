using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Services;

namespace talktomeweb.Pages.Account
{
    public class ProfileModel : PageModel
    {
        private readonly UserService _userService;
        private readonly PostService _postService;

        public List<SharedLibrary.Models.Post> Posts { get; set; }

        public dynamic SelectedUser { get; private set; }

        public ProfileModel(UserService userService, PostService postService)
        {
            _userService = userService;
            _postService = postService;
        }

        public void OnGet(int userId)
        {
            SelectedUser = _userService.GetUserById(userId);
            Posts = _postService.GetAllPostsByUser(userId);
        }
    }
}
