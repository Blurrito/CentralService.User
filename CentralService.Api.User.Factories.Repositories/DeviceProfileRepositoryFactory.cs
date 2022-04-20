using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentralService.Api.User.DataAccess.Repositories;
using CentralService.Api.User.Interfaces.Repositories;

namespace CentralService.Api.User.Factories.Repositories
{
    public static class DeviceProfileRepositoryFactory
    {
        public static IDeviceProfileRepository GetDeviceProfileRepository() => new DeviceProfileRepository();
    }
}
