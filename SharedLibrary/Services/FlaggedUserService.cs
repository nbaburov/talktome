using SharedLibrary.Models;
using SharedLibrary.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharedLibrary.Services
{
    public class FlaggedUserService
    {
        private readonly ModerationRepository _moderationRepository;
        private readonly UserService _userService;

        public FlaggedUserService(ModerationRepository moderationRepository)
        {
            _moderationRepository = moderationRepository;
            _userService = _moderationRepository.GetUserService();
        }

        public async Task<bool> FlagUser(int fromUserId, int toUserId, string reason)
        {
            if (await _moderationRepository.IsAlreadyFlagged(fromUserId, toUserId, null, null))
            {
                return false;
            }

            var flagUser = new FlagUser
            {
                FromUserId = fromUserId,
                ToUserId = toUserId,
                Reason = reason,
                CreationDate = DateTime.Now,
                Resolved = false,
                FromUser = _moderationRepository.GetFlaggedUsers().FirstOrDefault(u => u.FromUserId == fromUserId)?.FromUser,
                ToUser = _moderationRepository.GetFlaggedUsers().FirstOrDefault(u => u.ToUserId == toUserId)?.ToUser
            };
            await _moderationRepository.AddFlagUser(flagUser);
            return true;
        }

        public async Task<bool> BanUser(int userId)
        {
            var user = _userService.GetUserById(userId);
            if (user != null && user.Status != Status.Suspended)
            {
                await _userService.EditUser(user.UserId, user.Username, user.Email, user.ImagePath, null, user.RegistrationDate, user is Admin ? "Admin" : "Client", (user as Client)?.Bio, (int?)Status.Suspended, (int?)((user as Admin)?.Permission));
                return true;
            }
            return false;
        }

        public async Task<bool> UnBanUser(int userId)
        {
            var user = _userService.GetUserById(userId);
            if (user != null && user.Status == Status.Suspended)
            {
                await _userService.EditUser(user.UserId, user.Username, user.Email, user.ImagePath, null, user.RegistrationDate, user is Admin ? "Admin" : "Client", (user as Client)?.Bio, (int?)Status.Active, (int?)((user as Admin)?.Permission));
                return true;
            }
            return false;
        }


        public async Task<bool> RemoveFlaggedUser(int flagId)
        {
            await _moderationRepository.RemoveFlagUser(flagId);
            return true;
        }

        public FlagUser GetFlagUserById(int id)
        {
            return _moderationRepository.GetFlaggedUsers().FirstOrDefault(f => f.FlagId == id);
        }
        public FlagUser GetFlagUserByUserId(int id)
        {
            return _moderationRepository.GetFlaggedUsers().FirstOrDefault(f => f.ToUserId == id);
        }
    }
}
