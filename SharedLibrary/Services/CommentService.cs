using SharedLibrary.Models;
using SharedLibrary.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedLibrary.Services
{
    public class CommentService
    {
        private readonly ContentRepository _contentRepository;

        public CommentService(ContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public Comment GetCommentById(int commentId)
        {
            return _contentRepository.GetCommentById(commentId);
        }

        public List<Comment> GetCommentsByPostId(int postId)
        {
            return _contentRepository.GetCommentsByPostId(postId);
        }

        public async Task AddCommentAsync(string text, int userId, int postId)
        {
            var comment = new Comment
            {
                Text = text,
                UserId = userId,
                PostId = postId,
                CreationDate = DateTime.Now,
                User = _contentRepository.GetUserService().GetUserById(userId),
                Post = _contentRepository.GetPostById(postId)
            };

            await _contentRepository.AddComment(comment);
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            await _contentRepository.RemoveComment(commentId);
        }

        public async Task DeleteCommentsByPostIdAsync(int postId)
        {
            var comments = _contentRepository.GetCommentsByPostId(postId);
            foreach (var comment in comments)
            {
                await _contentRepository.RemoveComment(comment.CommentId);
            }
        }

        public int GetTotalComments()
        {
            return _contentRepository.GetComments().Count;
        }
    }
}
