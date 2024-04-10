using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Services;

namespace talktomeweb.Pages
{
    public class SearchResultsModel : PageModel
    {
        private readonly UserService _userService;
        private readonly PostService _postService;

        public SearchResultsModel(UserService userService, PostService postService)
        {
            _userService = userService;
            _postService = postService;
        }

        public List<dynamic> Users { get; set; }
        public List<SharedLibrary.Models.Post> Posts { get; set; }

        public void OnGet(string query)
        {
            Users = _userService.SearchUsers(query);
            Posts = _postService.SearchPosts(query);
        }
    }
}
