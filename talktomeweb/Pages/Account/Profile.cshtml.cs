using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Services;

namespace talktomeweb.Pages.Account
{
    public class ProfileModel : PageModel
    {
        private readonly UserService _userService;
        private readonly PostService _postService;
        private readonly ModerationService _moderationService;
        public List<SharedLibrary.Models.Post> Posts { get; set; }
        public dynamic SelectedUser { get; private set; }

        [BindProperty]
        public InputModel Input { get; set; }


        public class InputModel
        {
            [Required]
            public string Reason { get; set; }
            public int ToUserId { get; set; }
        }
        public ProfileModel(UserService userService, PostService postService, ModerationService moderationService)
        {
            _userService = userService;
            _postService = postService;
            _moderationService = moderationService;
        }

        public void OnGet(int userId)
        {
            SelectedUser = _userService.GetUserById(userId);

            if (SelectedUser != null)
            {
                Posts = SelectedUser.Posts ?? new List<SharedLibrary.Models.Post>();
            }
            else
            {
                RedirectToPage("/Index");
            }

            Input = new InputModel
            {
                Reason = "",
                ToUserId = SelectedUser.UserId
            };
        }

        public async Task<IActionResult> OnPostFlagUserAsync()
        {
            int fromUserId = _userService.GetCurrentlyLoggedInUser()?.UserId ?? 0;
            SelectedUser = _userService.GetUserById(Input.ToUserId);
            if (SelectedUser == null)
            {
                RedirectToPage("/Index");
            }

            Posts = SelectedUser.Posts ?? new List<SharedLibrary.Models.Post>();
            int toUserId = SelectedUser.UserId;

            bool noReason =
            Input.Reason == null || string.IsNullOrWhiteSpace(Input.Reason) || Input.Reason == "";


            if (noReason)
            {
                TempData["AlertTitle"] = "No reason.";
                TempData["AlertText"] = "No reason was detected in form.";
                TempData["AlertColor"] = "red";

                return RedirectToPage();
            }

            var result = await _moderationService.FlagUser(fromUserId, toUserId, Input.Reason);
            if (result)
            {
                TempData["AlertTitle"] = "Success.";
                TempData["AlertText"] = "You have successfully flagged the user.";
                TempData["AlertColor"] = "green";
            }
            else
            {
                TempData["AlertTitle"] = "Already Flagged.";
                TempData["AlertText"] = "User has been already flagged.";
                TempData["AlertColor"] = "yellow";
            }

            return RedirectToPage();
        }

    }
}
