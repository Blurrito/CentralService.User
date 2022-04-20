using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentralService.Api.User.Core;
using CentralService.Api.User.Interfaces.Managers;

namespace CentralService.Api.User.Factories.Managers
{
    public static class DeviceProfileManagerFactory
    {
        public static IDeviceProfileManager GetManager() => new DeviceProfileManager();
    }
}
