using CentralService.Api.User.DTO.Api.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Api.User.Interfaces.Managers
{
    public interface IBuddyManager : IDisposable
    {
        Task<ApiResponse?> AddBuddy(string GameCode, DTO.Api.User.Buddy Buddy);
        Task<ApiResponse?> GetBuddies(int SenderId);
        Task<ApiResponse?> GetIncomingRequests(int RecipientId);
        Task UpdateRequest(DTO.Api.User.Buddy Request);
        Task DeleteBuddy(int BuddyId);
    }
}
