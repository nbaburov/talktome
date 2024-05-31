using SharedLibrary.Models;
using SharedLibrary.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharedLibrary.Services
{
    public class FlaggedCommentService
    {
        private readonly ModerationRepository _moderationRepository;

        public FlaggedCommentService(ModerationRepository moderationRepository)
        {
            _moderationRepository = moderationRepository;
        }

        public async Task<bool> FlagComment(int fromUserId, int commentId)
        {
            if (await _moderationRepository.IsAlreadyFlagged(fromUserId, null, null, commentId))
            {
                return false;
            }

            var flagComment = new FlagComment
            {
                FromUserId = fromUserId,
                CommentId = commentId,
                CreationDate = DateTime.Now,
                Resolved = false,
                FromUser = _moderationRepository.GetFlaggedUsers().FirstOrDefault(u => u.FromUserId == fromUserId)?.FromUser,
                Comment = _moderationRepository.GetFlaggedComments().FirstOrDefault(c => c.CommentId == commentId)?.Comment
            };
            await _moderationRepository.AddFlagComment(flagComment);
            return true;
        }

        public async Task<bool> RemoveFlaggedComment(int flagId)
        {
            await _moderationRepository.RemoveFlagComment(flagId);
            return true;
        }

        public async Task<bool> DeleteFlaggedComment(int flagId)
        {
            var flagComment = _moderationRepository.GetFlaggedComments().FirstOrDefault(c => c.FlagId == flagId);
            if (flagComment != null)
            {
                await _moderationRepository.DeleteFlaggedComment(flagId);
                return true;
            }
            return false;
        }

        public FlagComment GetFlagCommentById(int id)
        {
            return _moderationRepository.GetFlaggedComments().FirstOrDefault(f => f.FlagId == id);
        }
        public FlagComment GetFlagCommentByCommentId(int id)
        {
            return _moderationRepository.GetFlaggedComments().FirstOrDefault(f => f.CommentId == id);
        }
    }
}
