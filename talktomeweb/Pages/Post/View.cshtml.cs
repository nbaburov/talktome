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
                return RedirectToPage(new { id = id });
            }
            Post = _postService.GetPostById(id);
            Console.Write(Post);
            if (Post == null)
            {
                return RedirectToPage("/Index");
            }

            var currentUser = _userService.GetCurrentlyLoggedInUser();
            if (currentUser == null)
            {
                return RedirectToPage("/Index");
            }

            Console.Write(!string.IsNullOrWhiteSpace(CommentText));
            if (!string.IsNullOrWhiteSpace(CommentText))
            {

                await _postService.AddCommentAsync(CommentText, currentUser.UserId, Post.PostId);
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

