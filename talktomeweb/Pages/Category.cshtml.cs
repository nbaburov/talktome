using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Models;
using SharedLibrary.Services;

namespace talktomeweb.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly CategoryService _categoryService;
        private readonly PostService _postService;

        public Category CategoryInfo { get; set; }
        public List<SharedLibrary.Models.Post> Posts { get; set; }

        public CategoryModel(PostService postService, CategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Assuming PostService has methods to get category info and posts by category ID
            CategoryInfo = _categoryService.GetCategoryById(id);
            Posts = _postService.GetPostsByCategoryId(id);

            if (CategoryInfo == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
