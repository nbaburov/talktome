using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Models;
using SharedLibrary.Repository;
using SharedLibrary.Services;

namespace talktomeweb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AuthService _authService;
        private readonly ContentRepository _contentRepo;
        public List<SharedLibrary.Models.Post> Posts { get; set; }
        public List<Category> Categories { get; set; }

        public IndexModel(ILogger<IndexModel> logger, AuthService authService, ContentRepository contentRepository)
        {
            _logger = logger;
            _authService = authService;
            _contentRepo = contentRepository;
        }

        public dynamic CurrentUser { get; private set; }

        public IActionResult OnGet()
        {
            Posts = _contentRepo.GetPosts();
            Categories = _contentRepo.GetCategories();
            CurrentUser = _authService.GetCurrentlyLoggedInUser();

            return Page();
        }
    }
}
