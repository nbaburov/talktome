using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Services;

namespace talktomeweb.Pages.Post
{
    public class FlagHandlerModel : PageModel
    {
        private readonly FlaggedPostService _flagPostService;
        public FlagHandlerModel(FlaggedPostService flaggedPostService)
        {
            _flagPostService = flaggedPostService;
        }
        public async Task<IActionResult> OnPostAsync(int fromUserId, int postId)
        {
            if (fromUserId == 0)
            {
                return RedirectToPage("/Account/Login");
            }
            var result = await _flagPostService.FlagPost(fromUserId, postId);
            if (result)
            {
                TempData["AlertTitle"] = "Success.";
                TempData["AlertText"] = "You have successfully flagged the post.";
                TempData["AlertColor"] = "green";
            }
            else
            {
                TempData["AlertTitle"] = "Already Flagged.";
                TempData["AlertText"] = "Post has been already flagged.";
                TempData["AlertColor"] = "yellow";
            }
            return RedirectToPage("/Index");
        }
    }
}
