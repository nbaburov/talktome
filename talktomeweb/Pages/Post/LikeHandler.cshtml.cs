using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace talktomeweb.Pages.Post
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using SharedLibrary.Services;
    using System.Threading.Tasks;

    public class LikeHandlerModel : PageModel
    {
        private readonly PostService _postService;
        private readonly UserService _userService;

        public LikeHandlerModel(PostService postService, UserService userService)
        {
            _postService = postService;
            _userService = userService;
        }

        public async Task<IActionResult> OnPostAsync(int postId, bool isLiked)
        {
            var user = _userService.GetCurrentlyLoggedInUser();
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            if (isLiked)
            {
                await _postService.UnlikePost(postId, user.UserId);
            }
            else
            {
                await _postService.LikePost(postId, user.UserId);
            }

            var referrerUrl = Request.Headers["Referer"].ToString();
            if (!string.IsNullOrEmpty(referrerUrl))
            {
                return Redirect(referrerUrl);
            }

            return RedirectToPage("/Index");
        }

    }

}
