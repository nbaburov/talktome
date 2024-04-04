using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLibrary.Services;
using SharedLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace talktomeweb.Pages
{
    public class SearchResultsModel : PageModel
    {
        private readonly UserService _userService;

        public SearchResultsModel(UserService userService)
        {
            _userService = userService;
        }

        public List<User> Users { get; set; }

        public void OnGet(string query)
        {
            Users = _userService.SearchUsers(query);
        }
    }
}
