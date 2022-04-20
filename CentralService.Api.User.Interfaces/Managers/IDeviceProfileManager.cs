using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentralService.Api.User.DTO.Api.Common;
using CentralService.Api.User.DTO.Api.User;

namespace CentralService.Api.User.Interfaces.Managers
{
    public interface IDeviceProfileManager : IDisposable
    {
        Task<ApiResponse?> CreateDeviceProfile(DeviceProfile Profile);
        Task<ApiResponse?> NasLogin(string Address, DeviceProfile Profile);
    }
}
