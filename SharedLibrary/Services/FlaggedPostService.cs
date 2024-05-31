using SharedLibrary.Models;
using SharedLibrary.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharedLibrary.Services
{
    public class FlaggedPostService
    {
        private readonly ModerationRepository _moderationRepository;

        public FlaggedPostService(ModerationRepository moderationRepository)
        {
            _moderationRepository = moderationRepository;
        }

        public async Task<bool> FlagPost(int fromUserId, int postId)
        {
            if (await _moderationRepository.IsAlreadyFlagged(fromUserId, null, postId, null))
            {
                return false;
            }

            var flagPost = new FlagPost
            {
                FromUserId = fromUserId,
                PostId = postId,
                CreationDate = DateTime.Now,
                Resolved = false,
                FromUser = _moderationRepository.GetFlaggedUsers().FirstOrDefault(u => u.FromUserId == fromUserId)?.FromUser,
                Post = _moderationRepository.GetFlaggedPosts().FirstOrDefault(p => p.PostId == postId)?.Post
            };
            await _moderationRepository.AddFlagPost(flagPost);
            return true;
        }

        public async Task<bool> RemoveFlaggedPost(int flagId)
        {
            await _moderationRepository.RemoveFlagPost(flagId);
            return true;
        }

        public async Task<bool> DeleteFlaggedPost(int flagId)
        {
            var flagPost = _moderationRepository.GetFlaggedPosts().FirstOrDefault(p => p.FlagId == flagId);
            if (flagPost != null)
            {
                await _moderationRepository.DeleteFlaggedPost(flagId);
                return true;
            }
            return false;
        }

        public FlagPost GetFlagPostById(int id)
        {
            return _moderationRepository.GetFlaggedPosts().FirstOrDefault(f => f.FlagId == id);
        }
        public FlagPost GetFlagPostByPostId(int id)
        {
            return _moderationRepository.GetFlaggedPosts().FirstOrDefault(f => f.PostId == id);
        }
    }
}
