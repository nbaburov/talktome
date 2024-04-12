using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Services;
using SharedLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace talktomeweb.Pages.Post
{
    public class ViewModel : PageModel
    {
        private readonly PostService _postService;
        private readonly UserService _userService;

        public SharedLibrary.Models.Post Post { get; set; }
        public List<SharedLibrary.Models.Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
        public dynamic? CurrentUser { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please enter a comment before posting.")]
        public string CommentText { get; set; }

        public ViewModel(PostService postService, UserService userService)
        {
            _postService = postService;
            _userService = userService;
            Posts = new List<SharedLibrary.Models.Post>();
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Post = _postService.GetPostById(id);
            CurrentUser = _userService.GetCurrentlyLoggedInUser();
            if (CurrentUser == null || Post == null)
            {
                return RedirectToPage("/Index");
            }
            Posts.Add(Post);
            Comments = (List<Comment>)Post.Comments;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                Post = _postService.GetPostById(id);
                Comments = (List<Comment>)Post.Comments;
                CurrentUser = _userService.GetCurrentlyLoggedInUser();
                Posts.Add(Post);
                return Page();
            }

            var currentUser = _userService.GetCurrentlyLoggedInUser();
            if (currentUser == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var currentPost = _postService.GetPostById(id);
            if (currentPost == null)
            {
                return RedirectToPage("/Index");
            }

            if (!string.IsNullOrWhiteSpace(CommentText))
            {
                await _postService.AddCommentAsync(CommentText, currentUser.UserId, currentPost.PostId);
                CommentText = string.Empty;
            }

            return RedirectToPage(new { id = id });
        }



        public async Task<IActionResult> OnPostDeleteCommentAsync(int id, int commentId)
        {

            await _postService.DeleteCommentAsync(commentId);

            return RedirectToPage(new { id = id });
        }

    }
}

