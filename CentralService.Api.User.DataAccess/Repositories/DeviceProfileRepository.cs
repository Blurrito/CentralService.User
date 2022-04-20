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
    public class DeviceProfileRepository : Repository<DeviceProfile>, IDeviceProfileRepository
    {
        public DeviceProfileRepository() : base() { }

        public async Task AddDeviceProfile(DeviceProfile Profile) => await Add(Profile);

        public async Task<List<DeviceProfile>> FindDeviceProfiles(Expression<Func<DeviceProfile, bool>> Predicate) => await Find(Predicate);

        public async Task<DeviceProfile> GetDeviceProfile(int DeviceProfileId) => await Get(x => x.DeviceProfileId == DeviceProfileId);

        public async Task<DeviceProfile> GetDeviceProfile(long DeviceId) => await Get(x => x.DeviceId == DeviceId);

        public async Task<List<DeviceProfile>> GetDeviceProfiles() => await Get();

        public void RemoveDeviceProfile(DeviceProfile Profile) => Remove(Profile);

        public void UpdateDeviceProfile(DeviceProfile Profile) => Update(Profile);
    }
}
