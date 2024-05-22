using SharedLibrary.Models;
using SharedLibrary.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedLibrary.Services
{
    public class CategoryService
    {
        private readonly ContentRepository _contentRepository;

        public CategoryService(ContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public async Task<Dictionary<int, string>> GetCategoriesAsync()
        {
            return _contentRepository.GetCategories().ToDictionary(c => c.CategoryId, c => c.Name);
        }

        public Category GetCategoryById(int categoryId)
        {
            return _contentRepository.GetCategoryById(categoryId);
        }
    }
}
