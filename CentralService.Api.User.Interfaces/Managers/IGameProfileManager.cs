using CentralService.Api.User.DTO.Api.Common;
using CentralService.Api.User.DTO.Api.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Api.User.Interfaces.Managers
{
    public interface IGameProfileManager : IDisposable
    {
        Task<ApiResponse?> GetGameProfile(int GameProfileId);
        Task<ApiResponse?> GetBuddyProfile(int GameProfileId, string BuddyLastName);
        Task UpdateGameProfile(GameProfile Profile);
    }
}
