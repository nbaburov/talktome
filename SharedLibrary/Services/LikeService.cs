using SharedLibrary.Models;
using SharedLibrary.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedLibrary.Services
{
    public class LikeService
    {
        private readonly ContentRepository _contentRepository;

        public LikeService(ContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public async Task LikePost(int postId, int userId)
        {
            if (_contentRepository.GetLikes().Any(l => l.PostId == postId && l.UserId == userId))
            {
                throw new InvalidOperationException("User has already liked the post.");
            }

            var like = new Like
            {
                UserId = userId,
                PostId = postId,
                CreationDate = DateTime.Now,
                User = _contentRepository.GetUserService().GetUserById(userId),
                Post = _contentRepository.GetPostById(postId)
            };

            await _contentRepository.AddLike(like);
        }

        public async Task UnlikePost(int postId, int userId)
        {
            var existingLike = _contentRepository.GetLikes().FirstOrDefault(l => l.PostId == postId && l.UserId == userId);
            if (existingLike == null)
            {
                throw new InvalidOperationException("User has not liked the post.");
            }

            await _contentRepository.RemoveLike(existingLike.LikeId);
        }

        public List<Like> GetLikesByPostId(int postId)
        {
            return _contentRepository.GetLikesByPostId(postId);
        }

        public int GetTotalLikes()
        {
            return _contentRepository.GetLikes().Count;
        }

        public async Task DeleteLikesByPostIdAsync(int postId)
        {
            var likes = _contentRepository.GetLikesByPostId(postId);
            foreach (var like in likes)
            {
                await _contentRepository.RemoveLike(like.LikeId);
            }
        }
    }
}
