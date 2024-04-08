using SharedLibrary.Models;
using SharedLibrary.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Services
{
    public class PostService
    {
        private readonly CategoryData _categoryData;
        private readonly PostData _postData;
        private readonly CommentData _commentData;
        private readonly LikeData _likeData;
        private readonly UserService _userService;


        public List<Category> Categories { get; private set; }
        public List<Post> Posts { get; private set; }
        public List<Comment> Comments { get; private set; }
        public List<Like> Likes { get; private set; }

        public PostService(string connectionString, UserService userService)
        {
            _categoryData = new CategoryData(connectionString);
            _postData = new PostData(connectionString);
            _commentData = new CommentData(connectionString);
            _likeData = new LikeData(connectionString);
            _userService = userService;

            LoadAllDataAsync().Wait();
        }


        // Loading Data

        private async Task LoadAllDataAsync()
        {
            // Load and Deserialize Categories
            var categoryJsonList = await _categoryData.GetAllCategories();
            Categories = categoryJsonList.Select(JsonConvert.DeserializeObject<Category>).ToList();

            // Load and Deserialize Posts
            var postJsonList = await _postData.GetAllPosts();
            var tempPosts = postJsonList.Select(JsonConvert.DeserializeObject<Post>).ToList();

            foreach (var post in tempPosts)
            {
                if (post.UserId != 0)
                {
                    post.User = _userService.GetUserById(post.UserId);
                }
                if (post.CategoryId != 0)
                {
                    post.Category = GetCategoryById(post.CategoryId);
                }
            }

            Posts = tempPosts;

            // Load and Deserialize Comments
            var commentJsonList = await _commentData.GetAllComments();
            Comments = commentJsonList.Select(JsonConvert.DeserializeObject<Comment>).ToList();

            // Load and Deserialize Likes
            var likeJsonList = await _likeData.GetAllLikes();
            Likes = likeJsonList.Select(JsonConvert.DeserializeObject<Like>).ToList();
        }

        // Post Management

        public async Task CreatePostAsync(string text, string imagePath, int categoryId, int userId)
        {
            var postId = await _postData.AddPost(text, imagePath, userId, categoryId);

            var user = _userService.GetUserById(userId);
            var category = GetCategoryById(categoryId);

            var post = new Post
            {
                PostId = postId,
                Text = text,
                ImagePath = imagePath,
                UserId = userId,
                User = user,
                CategoryId = categoryId,
                Category = category,
                CreationDate = DateTime.Now
            };

            Posts.Add(post);
        }

        public List<Post> GetAllPostsByUser(int userId)
        {
            return Posts.Where(p => p.UserId == userId).ToList();
        }


        public List<Post> GetPostsByCategoryId(int categoryId)
        {
            return Posts.Where(p => p.CategoryId == categoryId).ToList();
        }


        // Category Management

        public async Task<Dictionary<int, string>> GetCategoriesAsync()
        {
            return Categories.ToDictionary(c => c.CategoryId, c => c.Name);
        }
        public Category GetCategoryById(int categoryId)
        {
            return Categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }



    }
}
