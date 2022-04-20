using CentralService.Api.User.DTO.Api.Common;
using CentralService.Api.User.DTO.Database;
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
    public class BuddyManager : IBuddyManager
    {
        public async Task<ApiResponse?> AddBuddy(string GameCode, DTO.Api.User.Buddy Buddy)
        {
            await using (IBuddyRepository Repository = BuddyRepositoryFactory.GetRepository())
            {
                Buddy ExistingBuddy = await Repository.GetBuddyRequest(Buddy.SenderId, Buddy.RecipientId);
                if (ExistingBuddy != null)
                {
                    if (ExistingBuddy.Status == 2)
                        return new ApiResponse(false, new ApiError(1539, "The profile requested is already a buddy.", false));
                }
                else
                {
                    GameProfile RecipientProfile = null;
                    await using (IGameProfileRepository GameProfileRepository = GameProfileRepositoryFactory.GetGameProfileRepository())
                        RecipientProfile = await GameProfileRepository.GetGameProfile(Buddy.RecipientId);

                    if (RecipientProfile != null)
                        if (RecipientProfile.Gsbrcd.Substring(0, 4) == GameCode)
                        {
                            ExistingBuddy = new Buddy(Buddy);
                            await Repository.AddBuddy(ExistingBuddy);
                            return new ApiResponse(true, ExistingBuddy.BuddyId);
                        }
                }
                return new ApiResponse(true, 0);
            }
        }

        public async Task<ApiResponse?> GetBuddies(int SenderId)
        {
            await using (IBuddyRepository Repository = BuddyRepositoryFactory.GetRepository())
            {
                List<Buddy> FoundBuddies = await Repository.GetBuddyList(SenderId);
                List<DTO.Api.User.Buddy> ReturnList = new List<DTO.Api.User.Buddy>();
                foreach (Buddy Buddy in FoundBuddies)
                    ReturnList.Add(Buddy.ToBuddyDto());
                return new ApiResponse(true, ReturnList);
            }
        }

        public async Task<ApiResponse?> GetIncomingRequests(int RecipientId)
        {
            await using (IBuddyRepository Repository = BuddyRepositoryFactory.GetRepository())
            {
                List<Buddy> FoundBuddies = await Repository.GetIncomingRequests(RecipientId);
                List<DTO.Api.User.Buddy> ReturnList = new List<DTO.Api.User.Buddy>();
                foreach (Buddy Buddy in FoundBuddies)
                    ReturnList.Add(Buddy.ToBuddyDto());
                return new ApiResponse(true, ReturnList);
            }
        }

        public async Task UpdateRequest(DTO.Api.User.Buddy Request)
        {
            await using (IBuddyRepository Repository = BuddyRepositoryFactory.GetRepository())
            {
                Buddy ExistingBuddy = await Repository.GetBuddyRequest(Request.SenderId, Request.RecipientId);
                if (ExistingBuddy != null)
                {
                    ExistingBuddy.Status = Request.Status;
                    Repository.UpdateBuddy(ExistingBuddy);
                }
            }
        }

        public async Task DeleteBuddy(int BuddyId)
        {
            await using (IBuddyRepository Repository = BuddyRepositoryFactory.GetRepository())
            {
                Buddy ExistingBuddy = await Repository.GetBuddyRequest(BuddyId);
                if (ExistingBuddy != null)
                    Repository.RemoveBuddy(ExistingBuddy);
            }
        }

        public void Dispose() { }
    }
}
