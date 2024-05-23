using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Services;
using System.Threading.Tasks;

namespace talktomeweb.Pages.Post
{
    public class DeleteHandlerModel : PageModel
    {
        private readonly PostService _postService;
        private readonly AuthService _authService;

        public DeleteHandlerModel(PostService postService, AuthService authService)
        {
            _postService = postService;
            _authService = authService;
        }

        public async Task<IActionResult> OnPostAsync(int postId)
        {
            try
            {

                var user = _authService.GetCurrentlyLoggedInUser();
                if (user == null)
                {
                    return RedirectToPage("/Account/Login");
                }

                var post = _postService.GetPostById(postId);
                if (post == null || post.UserId != user.UserId)
                {
                    return RedirectToPage("/Index");
                }

                await _postService.DeletePostAsync(postId);
                TempData["AlertTitle"] = "Deleted.";
                TempData["AlertText"] = "The post has been deleted successfully.";
                TempData["AlertColor"] = "red";

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
