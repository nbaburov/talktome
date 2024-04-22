using SharedLibrary.Models;
using SharedLibrary.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace SharedLibrary.Services
{
    public class ModerationService
    {
        private readonly FlagData _flagData;
        private readonly UserService _userService;
        private readonly PostService _postService;
        public List<FlagUser> FlaggedUsers { get; private set; }
        public List<FlagPost> FlaggedPosts { get; private set; }
        public List<FlagComment> FlaggedComments { get; private set; }

        public ModerationService(IConfiguration configuration, UserService userService, PostService postService)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            _flagData = new FlagData(connectionString);

            _userService = userService;
            _postService = postService;

            LoadAllDataAsync().Wait();
        }

        // Loading Data

        private async Task LoadAllDataAsync()
        {
            FlaggedUsers = await _flagData.GetAllFlagUsers();
            foreach (var user in FlaggedUsers)
            {
                user.ToUser = _userService.GetUserById(user.ToUserId);
            }

            FlaggedPosts = await _flagData.GetAllFlagPosts();
            foreach (var post in FlaggedPosts)
            {
                post.Post = _postService.GetPostById(post.PostId);
            }

            FlaggedComments = await _flagData.GetAllFlagComments();
            foreach (var comment in FlaggedComments)
            {
                comment.Comment = _postService.GetCommentById(comment.CommentId);
            }
        }

        // Check
        private async Task<bool> IsAlreadyFlagged(int fromUserId, int? toUserId, int? postId, int? commentId)
        {
            return await _flagData.IsAlreadyFlagged(fromUserId, toUserId, postId, commentId);
        }

        // Adding Flags

        public async Task<bool> FlagUser(int fromUserId, int toUserId, string reason)
        {
            if (await IsAlreadyFlagged(fromUserId, toUserId, null, null))
            {
                return false;
            }
            var flagId = await _flagData.AddFlagUser(fromUserId, toUserId, reason);
            var fromUser = _userService.GetUserById(fromUserId);
            var toUser = _userService.GetUserById(toUserId);
            FlaggedUsers.Add(new FlagUser
            {
                FlagId = flagId,
                FromUserId = fromUserId,
                FromUser = fromUser,
                Resolved = false,
                CreationDate = DateTime.Now,
                ToUserId = toUserId,
                ToUser = toUser,
            });
            return true;
        }

        public async Task<bool> FlagPost(int fromUserId, int postId)
        {
            if (await IsAlreadyFlagged(fromUserId, null, postId, null))
            {
                return false;
            }
            var flagId = await _flagData.AddFlagPost(fromUserId, postId);
            var fromUser = _userService.GetUserById(fromUserId);
            var post = _postService.GetPostById(postId);
            FlaggedPosts.Add(new FlagPost
            {
                FlagId = flagId,
                FromUserId = fromUserId,
                FromUser = fromUser,
                Resolved = false,
                CreationDate = DateTime.Now,
                PostId = postId,
                Post = post,
            });
            return true;
        }

        public async Task<bool> FlagComment(int fromUserId, int commentId)
        {
            if (await IsAlreadyFlagged(fromUserId, null, null, commentId))
            {
                return false;
            }
            var flagId = await _flagData.AddFlagComment(fromUserId, commentId);
            var fromUser = _userService.GetUserById(fromUserId);
            var comment = _postService.GetCommentById(commentId);
            FlaggedComments.Add(new FlagComment
            {
                FlagId = flagId,
                FromUserId = fromUserId,
                FromUser = fromUser,
                Resolved = false,
                CreationDate = DateTime.Now,
                CommentId = commentId,
                Comment = comment,
            });
            return true;
        }
    }
}
