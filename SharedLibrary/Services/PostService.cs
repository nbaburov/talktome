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
            var categoryJsonList = await _categoryData.GetAllCategories();
            Categories = categoryJsonList.Select(JsonConvert.DeserializeObject<Category>).ToList();

            var postJsonList = await _postData.GetAllPosts();
            Posts = postJsonList.Select(JsonConvert.DeserializeObject<Post>).ToList();
            foreach (var post in Posts)
            {
                post.Category = GetCategoryById(post.CategoryId);
                post.User = _userService.GetUserById(post.UserId);
                post.User.Posts.Add(post);
            }

            var likeJsonList = await _likeData.GetAllLikes();
            Likes = likeJsonList.Select(JsonConvert.DeserializeObject<Like>).ToList();
            foreach (var like in Likes)
            {
                like.Post = GetPostById(like.PostId);
                like.User = _userService.GetUserById(like.UserId);
            }

            var commentJsonList = await _commentData.GetAllComments();
            Comments = commentJsonList.Select(JsonConvert.DeserializeObject<Comment>).ToList();
            foreach (var comment in Comments)
            {
                comment.Post = GetPostById(comment.PostId);
                comment.User = _userService.GetUserById(comment.UserId);
            }

            foreach (var post in Posts)
            {
                post.Likes = GetLikesByPostId(post.PostId);
                post.Comments = GetCommentsByPostId(post.PostId);
            }

        }


        // Post Management

        public List<Post> SearchPosts(string query)
        {
            return Posts
                .Where(post => post.Text.Contains(query, StringComparison.OrdinalIgnoreCase))
                .Select(post => post)
                .ToList();
        }

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

        public async Task DeletePostAsync(int postId)
        {
            var post = GetPostById(postId);
            if (post == null)
            {
                throw new KeyNotFoundException("Post not found.");
            }

            

            var likesToRemove = Likes.Where(l => l.PostId == postId).ToList();
            foreach (var like in likesToRemove)
            {
                Likes.Remove(like);
                post.Likes.Remove(like);
                await _likeData.DeleteLike(like.LikeId);
            }

            var commentsToRemove = Comments.Where(c => c.PostId == postId).ToList();
            foreach (var comment in commentsToRemove)
            {
                Comments.Remove(comment);
                await _commentData.DeleteComment(comment.CommentId);
            }

            await _postData.DeletePost(postId);
            Posts.Remove(post);
        }


        public List<Post> GetAllPostsByUser(int userId)
        {
            return Posts.Where(p => p.UserId == userId).ToList();
        }


        public List<Post> GetPostsByCategoryId(int categoryId)
        {
            return Posts.Where(p => p.CategoryId == categoryId).ToList();
        }

        public Post GetPostById(int postId)
        {
            return Posts.FirstOrDefault(p => p.PostId == postId);
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


        // Like Management
        public async Task LikePost(int postId, int userId)
        {
            if (Likes.Any(l => l.PostId == postId && l.UserId == userId))
            {
                throw new InvalidOperationException("User has already liked the post.");
            }

            var likeId = await _likeData.AddLike(userId, postId);
            var user = _userService.GetUserById(userId);
            var post = GetPostById(postId);

            var newLike = new Like
            {
                LikeId = likeId,
                UserId = user.UserId,
                User = user,
                PostId = post.PostId,
                Post = post,
                CreationDate = DateTime.Now
            };

            Likes.Add(newLike);
            post.Likes.Add(newLike);
        }

        public async Task UnlikePost(int postId, int userId)
        {
            var existingLike = Likes.FirstOrDefault(l => l.PostId == postId && l.UserId == userId);
            if (existingLike == null)
            {
                throw new InvalidOperationException("User has not liked the post.");
            }
            var post = GetPostById(postId);
            await _likeData.DeleteLike(existingLike.LikeId);

            Likes.Remove(existingLike);
            post.Likes.Remove(existingLike);
        }

        public List<Like> GetLikesByPostId(int postId)
        {
            return Likes.Where(l => l.PostId == postId).ToList();
        }

        // Category Management

        public List<Comment> GetCommentsByPostId(int postId)
        {
            return Comments.Where(c => c.PostId == postId).ToList();
        }



    }
}
