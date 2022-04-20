using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CentralService.Api.User.DTO.Database;

namespace CentralService.Api.User.Interfaces.Repositories
{
    public interface IGameProfileRepository : IRepository<GameProfile>
    {
        Task<GameProfile> GetGameProfile(int GameProfileId);
        Task<GameProfile> GetGameProfile(string LastName);
        Task<GameProfile> GetGameProfile(int DeviceProfileId, string Gsbrcd);
        Task<List<GameProfile>> GetGameProfiles();
        Task<List<GameProfile>> FindGameProfiles(Expression<Func<GameProfile, bool>> Predicate);
        Task AddGameProfile(GameProfile GameProfile);
        void UpdateGameProfile(GameProfile GameProfile);
        void RemoveGameProfile(GameProfile GameProfile);
    }
}