using SharedLibrary.Models;
using SharedLibrary.Data;
using SharedLibrary.Interface;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedLibrary.Services;

namespace SharedLibrary.Repository
{
    public class ContentRepository
    {
        private readonly CategoryData _categoryData;
        private readonly PostData _postData;
        private readonly CommentData _commentData;
        private readonly LikeData _likeData;
        private readonly UserService _userService;

        private List<Category> _categories;
        private List<Post> _posts;
        private List<Comment> _comments;
        private List<Like> _likes;

        public ContentRepository(IServiceConfig config, UserService userService)
        {
            string connectionString = config.ConnectionString;
            _categoryData = new CategoryData(connectionString);
            _postData = new PostData(connectionString);
            _commentData = new CommentData(connectionString);
            _likeData = new LikeData(connectionString);
            _userService = userService;

            LoadAllDataAsync().Wait();
        }

        private async Task LoadAllDataAsync()
        {
            var categoryJsonList = await _categoryData.GetAllCategories();
            _categories = categoryJsonList.Select(JsonConvert.DeserializeObject<Category>).ToList();

            var postJsonList = await _postData.GetAllPosts();
            _posts = postJsonList.Select(JsonConvert.DeserializeObject<Post>).ToList();
            foreach (var post in _posts)
            {
                post.Category = GetCategoryById(post.CategoryId);
                post.User = _userService.GetUserById(post.UserId);
                post.User.Posts.Add(post);
            }

            var likeJsonList = await _likeData.GetAllLikes();
            _likes = likeJsonList.Select(JsonConvert.DeserializeObject<Like>).ToList();
            foreach (var like in _likes)
            {
                like.Post = GetPostById(like.PostId);
                like.User = _userService.GetUserById(like.UserId);
            }

            var commentJsonList = await _commentData.GetAllComments();
            _comments = commentJsonList.Select(JsonConvert.DeserializeObject<Comment>).ToList();
            foreach (var comment in _comments)
            {
                comment.Post = GetPostById(comment.PostId);
                comment.User = _userService.GetUserById(comment.UserId);
            }

            foreach (var post in _posts)
            {
                post.Likes = GetLikesByPostId(post.PostId);
                post.Comments = GetCommentsByPostId(post.PostId);
            }
        }

        public List<Category> GetCategories() => _categories;
        public List<Post> GetPosts() => _posts;
        public List<Comment> GetComments() => _comments;
        public List<Like> GetLikes() => _likes;

        public async Task AddPost(Post post)
        {
            _posts.Add(post);
            await _postData.AddPost(post.Text, post.ImagePath, post.UserId, post.CategoryId);
        }

        public async Task AddComment(Comment comment)
        {
            _comments.Add(comment);
            await _commentData.AddComment(comment.Text, comment.UserId, comment.PostId);
        }

        public async Task AddLike(Like like)
        {
            _likes.Add(like);
            await _likeData.AddLike(like.UserId, like.PostId);
        }

        public async Task RemovePost(int postId)
        {
            var post = _posts.FirstOrDefault(p => p.PostId == postId);
            if (post != null)
            {
                _posts.Remove(post);
                await _postData.DeletePost(postId);
            }
        }

        public async Task RemoveComment(int commentId)
        {
            var comment = _comments.FirstOrDefault(c => c.CommentId == commentId);
            if (comment != null)
            {
                _comments.Remove(comment);
                await _commentData.DeleteComment(commentId);
            }
        }

        public async Task RemoveLike(int likeId)
        {
            var like = _likes.FirstOrDefault(l => l.LikeId == likeId);
            if (like != null)
            {
                _likes.Remove(like);
                await _likeData.DeleteLike(likeId);
            }
        }

        public Category GetCategoryById(int categoryId) => _categories.FirstOrDefault(c => c.CategoryId == categoryId);
        public Post GetPostById(int postId) => _posts.FirstOrDefault(p => p.PostId == postId);
        public Comment GetCommentById(int commentId) => _comments.FirstOrDefault(c => c.CommentId == commentId);
        public List<Like> GetLikesByPostId(int postId) => _likes.Where(l => l.PostId == postId).ToList();
        public List<Comment> GetCommentsByPostId(int postId) => _comments.Where(c => c.PostId == postId).ToList();
        
        public UserService GetUserService()
        {
            return _userService;
        }
    }
}
