using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CentralService.Api.User.DTO.Database;

namespace CentralService.Api.User.Interfaces.Repositories
{
    public interface IDeviceProfileRepository : IRepository<DeviceProfile>
    {
        Task<DeviceProfile> GetDeviceProfile(int DeviceProfileId);
        Task<DeviceProfile> GetDeviceProfile(long DeviceId);
        Task<List<DeviceProfile>> GetDeviceProfiles();
        Task<List<DeviceProfile>> FindDeviceProfiles(Expression<Func<DeviceProfile, bool>> Predicate);
        Task AddDeviceProfile(DeviceProfile DeviceProfile);
        void UpdateDeviceProfile(DeviceProfile DeviceProfile);
        void RemoveDeviceProfile(DeviceProfile DeviceProfile);
    }
}
