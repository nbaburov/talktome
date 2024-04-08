using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace talktomeweb.Pages.Post
{
    public class CreateModel : PageModel
    {
        private readonly PostService _postService;
        private readonly UserService _userService;

        public CreateModel(PostService postService, UserService userService)
        {
            _postService = postService;
            _userService = userService;
        }

        [BindProperty]
        public PostInputModel Input { get; set; }

        public Dictionary<int, string> Categories { get; set; }

        public class PostInputModel
        {
            public string Text { get; set; }
            public IFormFile Image { get; set; }
            public int CategoryId { get; set; }
        }

        public async Task OnGetAsync()
        {
            Categories = await _postService.GetCategoriesAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(Input.Text) && Input.Image == null)
            {
                ModelState.AddModelError("Input.Text", "Either text or an image is required.");
                ModelState.AddModelError("Input.Image", "Either text or an image is required.");
            }

            var currentUser = _userService.GetCurrentlyLoggedInUser();
            if (currentUser == null)
            {
                return RedirectToPage("/Account/Login");
            }

            string imagePath = ProcessUploadedFile(Input.Image);

            await _postService.CreatePostAsync(Input.Text, imagePath, Input.CategoryId, currentUser.UserId);

            return RedirectToPage("/Index");
        }

        private string ProcessUploadedFile(IFormFile file)
        {
            string uniqueFileName = null;

            if (file != null)
            {

                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/posts");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }

}
