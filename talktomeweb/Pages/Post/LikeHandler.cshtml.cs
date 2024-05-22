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
        private readonly LikeService _likeService;
        private readonly AuthService _authService;

        public LikeHandlerModel(LikeService likeService, AuthService authService)
        {
            _likeService = likeService;
            _authService = authService;
        }

        public async Task<IActionResult> OnPostAsync(int postId, bool isLiked)
        {
            var user = _authService.GetCurrentlyLoggedInUser();
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            if (isLiked)
            {
                await _likeService.UnlikePost(postId, user.UserId);
            }
            else
            {
                await _likeService.LikePost(postId, user.UserId);
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
