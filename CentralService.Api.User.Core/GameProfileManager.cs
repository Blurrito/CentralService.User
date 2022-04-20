using CentralService.Api.User.DTO.Api.Common;
using CentralService.Api.User.DTO.Api.User;
using CentralService.Api.User.Factories.Repositories;
using CentralService.Api.User.Interfaces.Managers;
using CentralService.Api.User.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Api.User.Core
{
    public class GameProfileManager : IGameProfileManager
    {
        public GameProfileManager() { }

        internal async Task<GameProfile> CreateGameProfile(int DeviceProfileId, long DeviceId, string Gsbrcd, string GameCode)
        {
            DTO.Database.GameProfile ExistingProfile = null;
            await using (IGameProfileRepository Repository = GameProfileRepositoryFactory.GetGameProfileRepository())
            {
                ExistingProfile = await Repository.GetGameProfile(DeviceProfileId, Gsbrcd);
                if (ExistingProfile == null)
                {
                    ExistingProfile = new DTO.Database.GameProfile(Gsbrcd, GameCode, DeviceId, DeviceProfileId);
                    await Repository.AddGameProfile(ExistingProfile);
                }
            }
            return ExistingProfile.ToGameProfileDTO();
        }

        public async Task<ApiResponse?> GetGameProfile(int GameProfileId)
        {
            DTO.Database.GameProfile ExistingProfile = null;
            await using (IGameProfileRepository Repository = GameProfileRepositoryFactory.GetGameProfileRepository())
            {
                ExistingProfile = await Repository.GetGameProfile(GameProfileId);
                if (ExistingProfile == null)
                    return new ApiResponse(false, null);
            }
            return new ApiResponse(true, ExistingProfile.ToGameProfileDTO());
        }

        public async Task<ApiResponse?> GetBuddyProfile(int GameProfileId, string BuddyLastName)
        {
            DTO.Database.GameProfile ExistingProfile = null;
            await using (IGameProfileRepository Repository = GameProfileRepositoryFactory.GetGameProfileRepository())
                ExistingProfile = await Repository.GetGameProfile(BuddyLastName);
            if (ExistingProfile == null)
                return new ApiResponse(false, null);

            DTO.Database.Buddy ExistingBuddy = null;
            await using (IBuddyRepository BuddyRepository = BuddyRepositoryFactory.GetRepository())
                ExistingBuddy = await BuddyRepository.GetBuddyRequest(GameProfileId, ExistingProfile.GameProfileId);
            if (ExistingBuddy == null)
                return new ApiResponse(false, null);
            else if (ExistingBuddy.Status == 0)
                return new ApiResponse(false, null);
            return new ApiResponse(true, ExistingProfile.ToGameProfileDTO());
        }

        public async Task UpdateGameProfile(GameProfile Profile)
        {
            DTO.Database.GameProfile ExistingProfile = null;
            await using (IGameProfileRepository Repository = GameProfileRepositoryFactory.GetGameProfileRepository())
            {
                ExistingProfile = await Repository.GetGameProfile(Profile.GameProfileId);
                if (ExistingProfile != null)
                {
                    ExistingProfile.Update(Profile);
                    Repository.UpdateGameProfile(ExistingProfile);
                }
            }
        }

        public void Dispose() { }
    }
}
