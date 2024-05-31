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
        private readonly CommentService _commentService;
        private readonly AuthService _authService;
        public FlaggedCommentService _flagCommentService;

        public SharedLibrary.Models.Post Post { get; set; }
        public List<SharedLibrary.Models.Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
        public dynamic? CurrentUser { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please enter a comment before posting.")]
        public string CommentText { get; set; }

        public ViewModel(PostService postService, AuthService authService, FlaggedCommentService flaggedCommentService, CommentService commentService)
        {
            _postService = postService;
            _authService = authService;
            _commentService = commentService;
            _flagCommentService = flaggedCommentService;
            Posts = new List<SharedLibrary.Models.Post>();
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Post = _postService.GetPostById(id);
            CurrentUser = _authService.GetCurrentlyLoggedInUser();
            if (CurrentUser == null)
            {
                return RedirectToPage("/Account/Login");
            }
            if (Post == null)
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
                CurrentUser = _authService.GetCurrentlyLoggedInUser();
                Posts.Add(Post);
                return Page();
            }

            var currentUser = _authService.GetCurrentlyLoggedInUser();
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
                await _commentService.AddCommentAsync(CommentText, currentUser.UserId, currentPost.PostId);
                CommentText = string.Empty;
            }

            return RedirectToPage(new { id = id });
        }



        public async Task<IActionResult> OnPostDeleteCommentAsync(int id, int commentId)
        {

            await _commentService.DeleteCommentAsync(commentId);

            return RedirectToPage(new { id = id });
        }
        public async Task<IActionResult> OnPostFlagHandler(int id, int fromUserId, int commentId)
        {

            var result = await _flagCommentService.FlagComment(fromUserId, commentId);
            if (result)
            {
                TempData["AlertTitle"] = "Success.";
                TempData["AlertText"] = "You have successfully flagged the comment.";
                TempData["AlertColor"] = "green";
            }
            else
            {
                TempData["AlertTitle"] = "Already Flagged.";
                TempData["AlertText"] = "Comment has been already flagged.";
                TempData["AlertColor"] = "yellow";
            }
            return RedirectToPage(new { id = id });
        }

    }
}

