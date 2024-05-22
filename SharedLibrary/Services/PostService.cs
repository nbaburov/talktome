using SharedLibrary.Models;
using SharedLibrary.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedLibrary.Services
{
    public class PostService
    {
        private readonly ContentRepository _contentRepository;

        public PostService(ContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public List<Post> SearchPosts(string query)
        {
            return _contentRepository.GetPosts()
                .Where(post => post.Text.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public async Task CreatePostAsync(string text, string imagePath, int categoryId, int userId)
        {
            var post = new Post
            {
                Text = text,
                ImagePath = imagePath,
                UserId = userId,
                CategoryId = categoryId,
                CreationDate = DateTime.Now,
                User = _contentRepository.GetUserService().GetUserById(userId),
                Category = _contentRepository.GetCategoryById(categoryId)
            };

            await _contentRepository.AddPost(post);
        }

        public async Task DeletePostAsync(int postId)
        {
            await _contentRepository.RemovePost(postId);
        }

        public List<Post> GetAllPostsByUser(int userId)
        {
            return _contentRepository.GetPosts().Where(p => p.UserId == userId).ToList();
        }

        public List<Post> GetPostsByCategoryId(int categoryId)
        {
            return _contentRepository.GetPosts().Where(p => p.CategoryId == categoryId).ToList();
        }

        public Post GetPostById(int postId)
        {
            return _contentRepository.GetPostById(postId);
        }

        public int GetTotalPosts()
        {
            return _contentRepository.GetPosts().Count;
        }

        public int GetPostsCreatedToday()
        {
            return _contentRepository.GetPosts().Count(p => p.CreationDate.Date == DateTime.Today);
        }
    }
}
