using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CentralService.Api.User.Interfaces.Repositories;
using CentralService.Api.User.DTO.Database;

namespace CentralService.Api.User.DataAccess.Repositories
{
    public class GameProfileRepository : Repository<GameProfile>, IGameProfileRepository
    {
        public GameProfileRepository() : base() { }

        public Task AddGameProfile(GameProfile GameProfile) => Add(GameProfile);
        public async Task<GameProfile> GetGameProfile(int GameProfileId) => await Get(x => x.GameProfileId == GameProfileId);

        public async Task<GameProfile> GetGameProfile(string LastName) => await Get(x => x.LastName == LastName);

        public async Task<GameProfile> GetGameProfile(int DeviceprofileId, string Gsbrcd) => await Get(x => x.DeviceProfileId == DeviceprofileId && x.Gsbrcd == Gsbrcd);

        public async Task<List<GameProfile>> FindGameProfiles(Expression<Func<GameProfile, bool>> Predicate) => await Find(Predicate);

        public async Task<List<GameProfile>> GetGameProfiles() => await Get();

        public void RemoveGameProfile(GameProfile GameProfile) => Remove(GameProfile);

        public void UpdateGameProfile(GameProfile GameProfile) => Update(GameProfile);
    }
}
